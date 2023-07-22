using StoreManagement.Models;

namespace StoreManagement.IService
{
    public interface IStorageDetailServices
    {
        public void AddStorageDetails(List<string> storages, string pid);
        public List<StorageDetail> GetStorageDetails(string pid);
        public int RemoveStorage(int id);
        public int UpdateStorageDetails(List<StorageDetail> storageDetails);

    }
}
