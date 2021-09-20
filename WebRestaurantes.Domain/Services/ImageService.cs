using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public class ImageService : BaseService<Image, IImageRepository>, IImageService
    {
        public ImageService(IImageRepository ImageRepository) : base(ImageRepository)
        {
        }
    }
}
