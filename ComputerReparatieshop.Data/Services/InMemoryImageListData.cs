using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class InMemoryImageListData : IImageListData
    {
        private List<ImageList> imageLists;

        public InMemoryImageListData()
        {
            imageLists = new List<ImageList>();
        }

        public IEnumerable<ImageList> Get(int id)
        {
            List<ImageList> returningList = new List<ImageList>();
            foreach(ImageList image in imageLists)
            {
                if (image.Id == id)
                {
                    returningList.Add(image);
                }
            }
            return returningList;
        }

        public IEnumerable<ImageList> GetAll()
        {
            return imageLists;
        }
    }
}
