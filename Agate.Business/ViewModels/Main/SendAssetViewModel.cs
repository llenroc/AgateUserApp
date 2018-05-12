using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Agate.Business.AppLogic;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Agate.Contracts.Models.PaymentRequest;
using Agate.Contracts.Models.Transactions;
using Microsoft.AppCenter.Crashes;
using Plugin.Connectivity.Abstractions;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;
using Xamarin.Forms;
using ZXing;

namespace Agate.Business.ViewModels.Main
{
    public class SendAssetViewModel : BaseViewModel
    {
        private readonly ITransactionService transactionService;
        private readonly IPaymentRequestService paymentRequestService;
        private readonly IAppData appData;
        private readonly IUserData userData;
        private readonly ISecureStorage secureStorage;
        private readonly IConnectivity connectivity;
        private Asset asset;
        private UserAsset userAsset;
        private bool showCamera;
        private Result scanResult;
        private bool isScanning;
        private bool isAnalyzing;
        private int paymentRequestId = 0;

        public SendAssetViewModel(ITransactionService transactionService, IPaymentRequestService paymentRequestService, IAppData appData, IUserData userData, ISecureStorage secureStorage, IConnectivity connectivity)
        {
            this.transactionService = transactionService;
            this.paymentRequestService = paymentRequestService;
            this.appData = appData;
            this.userData = userData;
            this.secureStorage = secureStorage;
            this.connectivity = connectivity;
        }

        public void Initialize(Asset asset, UserAsset userAsset)
        {
            this.asset = asset;
            this.userAsset = userAsset;

            Amount = new Property<decimal>("amount")
                .Required("Please enter an amount.")
                .Check(amount => (userAsset.Balance >= amount), "Insufficient funds");
            SendAddress = new Property<string>("address").RequiredString("Please specify address.");
            SendCommand = new XCommand(async () => await Send(), CanSend);

            CameraCommand = new XCommand(OpenCamera);
            ScanResultCommand = new XCommand(ProcessScanResult);
            SendCommand.SetDependency(this, Amount, SendAddress);
        }


        public Property<decimal> Amount { get; set; }
        public Property<string> SendAddress { get; set; }

        public bool ShowCamera
        {
            get => showCamera;
            set
            {
                if (showCamera == value)
                    return;
                showCamera = value;
                Raise(nameof(ShowCamera));
            }
        }

        public bool IsScanning
        {
            get => isScanning; set
            {
                if (isScanning == value)
                    return;
                isScanning = value;
                Raise(nameof(IsScanning));
            }
        }

        public bool IsAnalyzing
        {
            get => isAnalyzing; set
            {
                if(isAnalyzing == value)
                    return;
                isAnalyzing = value;
                Raise(nameof(IsAnalyzing));
            }
        }

        public Result ScanResult
        {
            get => scanResult;
            set
            {
                scanResult = value;

                try
                {
                    if (scanResult != null)
                    {
                        var code = scanResult.Text;
                        (var address, var assetId, var requestId, var amount) = ParseQRCode(code);
                        if(address == null)
                            return;
                        paymentRequestId = requestId;

                        //if(assetId != asset.AssetId)
                        //{
                        //    // todo :handle it when address is for a different asset
                        //}
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            ShowCamera = false;
                            Amount.Value = amount;
                            SendAddress.Value = address;
                        });
                    }
                }
                catch(Exception ex)
                {
                    Crashes.TrackError(ex, new Dictionary<string, string>{});
                }

                (string,string,int, decimal) ParseQRCode(string code)
                {
                    try
                    {
                        var pattern = @"agate:\/\/(?<address>.*)_(?<paymentRequestId>\d+)\?asset=(?<assetId>.*)&amount=(?<amount>.*)";
                        var result = Regex.Match(code, pattern);
                        if (result.Success)
                        {
                            var address = result.Groups["address"].Value;
                            var requestId = Int32.Parse(result.Groups["paymentRequestId"].Value);
                            var assetId = result.Groups["assetId"].Value;
                            var amount = decimal.Parse(result.Groups["amount"].Value);
                            return (address, assetId, requestId, amount);
                        }
                        return (null, null, 0, 0);
                    }
                    catch
                    {
                        return (null, null,0, 0);
                    }
                }
            }
        }

        public IXCommand SendCommand { get; set; }
        public IXCommand CameraCommand { get; set; }

        public void OpenCamera()
        {
            ShowCamera = !ShowCamera;
            IsScanning = ShowCamera;
            IsAnalyzing = ShowCamera;
        }

        public IXCommand ScanResultCommand { get; set; }

        public void ProcessScanResult()
        {

        }

        public bool CanSend()
        {
            return IsNotBusy && Validation.Check(Amount, SendAddress);
        }

        public async Task Send()
        {
            try
            {
                if (!connectivity.IsConnected)
                {
                    await View.DisplayAlert("...", "Internet connection required", "Ok");
                    return;
                }

                if (paymentRequestId > 0)
                {
                    try
                    {
                        using (WorkingScope.Enter())
                        {
                            await paymentRequestService.Pay(paymentRequestId, new PaymentSubmission {Amount = Amount.Value, AssetId = asset.AssetId});
                        }
                    }
                    catch(Exception ex)
                    {
                        Crashes.TrackError(ex, new Dictionary<string, string> { {"page","send asset"}, { "operation", "pay paymentrequest" } });
                    }
                }

                var request = new SendOrderRequest
                {
                    Amount = Amount.Value,
                    TargetAddress = SendAddress.Value,
                    AssetId = asset.AssetId,
                    UserId = secureStorage.GetUserId().Value,
                    AcceptedFee = 0,
                };

                SendOrderResponse response;
                using (WorkingScope.Enter())
                {
                    response = await transactionService.SendOrder(request);
                }

                userAsset.Balance = response.AssetNewBalance;

                await userData.SaveUserAssets(appData.UserAssets);

                await View.DisplayAlert("Done", "Send order submitted.", "Ok");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                    {
                        {"page", "send asset"},
                        {"operation", $"{nameof(SendAssetViewModel)}.{nameof(Send)}"}
                    });
                await View.DisplayAlert("Error", "An error occurred while processing your request" + ex, "Ok");
            }
        }
    }
}