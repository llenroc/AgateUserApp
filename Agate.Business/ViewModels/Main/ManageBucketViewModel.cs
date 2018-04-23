using System;
using System.Collections.Generic;
using System.Text;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class ManageBucketViewModel : BaseViewModel
    {
        public ManageBucketViewModel(HomePageBucketInfoViewModel homePageBucketInfoViewModel)
        {
            Bucket = homePageBucketInfoViewModel;
        }

        public HomePageBucketInfoViewModel Bucket { get; set; }
    }
}
