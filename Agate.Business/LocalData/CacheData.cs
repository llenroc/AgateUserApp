using System;

namespace Agate.Business.LocalData
{
    public class CacheData<TData>
    {
        public CacheData(TData data, TimeSpan validUntil)
            : this(data, DateTime.Now.Add(validUntil))
        {
        }

        public CacheData(TData data, DateTime? validUntil = null)
        {
            Data = data;
            TimeLoaded = DateTime.Now;
            ValidUntilDateTime = validUntil;
        }

        public DateTime TimeLoaded { get; set; }
        public DateTime? ValidUntilDateTime { get; set; }
        public TData Data { get; set; }
    }
}
