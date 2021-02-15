using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;

namespace ComputerReparatieshop.Infrastructure.Services
{
    public class InMemoryImageData : IImageData
    {
        private List<Image> imageLists;

        public InMemoryImageData()
        {
            imageLists = new List<Image>();
        }

        public IEnumerable<Image> Get(int id)
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

        IEnumerable<Domain.Models.Image> IImageData.Get(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Domain.Models.Image> IImageData.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
