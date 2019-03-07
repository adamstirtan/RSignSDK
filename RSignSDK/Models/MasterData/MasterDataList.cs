using System.Collections.Generic;

namespace RSignSDK.Models.MasterData
{
    public class MasterDataList<T> where T : class
    {
        public IList<T> MasterList { get; set; }
    }
}