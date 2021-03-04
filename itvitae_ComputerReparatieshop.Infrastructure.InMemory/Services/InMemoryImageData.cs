using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Infrastructure.InMemory.Services
{
    public class InMemoryImageData : IImageData
    {
        private readonly List<Image> imageLists;

        public InMemoryImageData()
        {
            imageLists = new List<Image>() { new Image() { Id = 0, ImagePath = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcR3xZBSDJnZPEoXZhBPErMPN9UN-RFB_nauvJ0nStE8s1K5MI10L63pZ9AEyfA-Wbe3F1tLZJeq2Q&usqp=CAc", OrderId = 0 } };
        }

        public void Create(Image image)
        {
            if (imageLists.Count > 0)
            {
                image.Id = imageLists.Max(i => i.Id);
            }
            imageLists.Add(image);
        }

        public void Delete(Image image)
        {
            imageLists.Remove(image);
        }

        public IEnumerable<Image> GetOrderImages(int id)
        {
            List<Image> returningList = new List<Image>();
            foreach(Image image in imageLists)
            {
                if (image.Id == id)
                {
                    returningList.Add(image);
                }
            }
            return returningList;
        }

        public IEnumerable<Image> GetAll()
        {
            return imageLists;
        }

        public Image Get(int id)
        {
            return imageLists.SingleOrDefault(i => i.Id == id);
        }
    }
}
