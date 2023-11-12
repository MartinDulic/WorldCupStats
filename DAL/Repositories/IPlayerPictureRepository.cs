using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPlayerPictureRepository
    {
        public IDictionary<string,string> GetAllPicturePaths();
        public void SaveAllPictures(IDictionary<string,string> picturePaths);

    }
}
