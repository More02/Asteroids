using System;
using Model;
using Unity.VisualScripting;
using View;

namespace Controller
{
    public interface IControllerFolBorders
    {
        public IModelForBorder GetModel();
        public IViewForBorder GetView();
    }
}