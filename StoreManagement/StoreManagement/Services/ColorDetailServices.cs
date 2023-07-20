using StoreManagement.IService;
using StoreManagement.Models;

namespace StoreManagement.Services
{
    public class ColorDetailServices : IColorDetailServices
    {
        private readonly WebContext _context;
        public ColorDetailServices(WebContext context)
        {
            _context = context;
        }
        public void AddColorDetails(List<string> colors, string pid)
        {
            List<ColorDetail> colorsList = new List<ColorDetail>();
            foreach (string color in colors)
            {
                colorsList.Add(new ColorDetail { Pid = pid, Color = color });
            };
            _context.AddRange(colorsList);
            _context.SaveChanges();
        }
    }
}
