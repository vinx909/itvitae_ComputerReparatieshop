using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
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
    }
}
