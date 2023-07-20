using StoreManagement.IService;
using StoreManagement.Models;

namespace StoreManagement.Services
{
    public class StorageDetailServices : IStorageDetailServices
    {
        private readonly WebContext _context;
        public StorageDetailServices(WebContext context)
        {
            _context = context;
        }
        public void AddStorageDetails(List<string> storages, string pid)
        {
            List<StorageDetail> storageDetails = new List<StorageDetail>();
            foreach (string storage in storages)
            {
                storageDetails.Add(new StorageDetail { Pid = pid, Storage = storage });
            };
            _context.AddRange(storageDetails);
            _context.SaveChanges();
        }
    }
}
