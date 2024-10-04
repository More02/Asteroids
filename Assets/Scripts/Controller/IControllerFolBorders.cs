using Model;
using View;

namespace Controller
{
    public interface IControllerFolBorders
    {
        public IModelForBorder GetModel();
        public IViewForBorder GetView();
    }
}