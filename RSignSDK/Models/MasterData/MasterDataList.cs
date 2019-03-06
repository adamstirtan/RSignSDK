using System.Collections.Generic;

namespace RSignSDK.Models.MasterData
{
    public class MasterDataList<T> where T : MasterData
    {
        public IList<T> MasterList { get; set; }
    }
}