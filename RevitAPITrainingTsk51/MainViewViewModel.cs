using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Prism.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingTsk51
{
    class MainViewViewModel
    {
        private ExternalCommandData _commandData;
        public MainViewViewModel(ExternalCommandData commandData)
        {
            //для взаимодействия с UI docment
            _commandData = commandData;
            //SelectCommand = new DelegateCommand(OnSelectCommand);
            NumberPipesCommand = new DelegateCommand(OnNumPipeComm);
            VolumeWallCommand = new DelegateCommand(OnVolWallCom);
            NumberDoorCommand = new DelegateCommand(OnNumDoorCom);
        }

        public DelegateCommand NumberPipesCommand { get; }
        public DelegateCommand VolumeWallCommand { get; }
        public DelegateCommand NumberDoorCommand { get; }

        private void OnNumDoorCom()
        {
            RaiseHideRequest();

            List<Element> oElement = ElementCount.PickObjects(_commandData, BuiltInCategory.OST_Doors);

            TaskDialog.Show("Количество дверей", $"Двери: {oElement.Count} шт.");

            RaiseShowRequest();
        }

        private void OnVolWallCom()
        {
            RaiseHideRequest();
            double volume = VolWallCount.Volume(_commandData);
            TaskDialog.Show("Объем стен", $"Объем стен: {volume} м3");
            RaiseShowRequest();
        }

        private void OnNumPipeComm()
        {
            RaiseHideRequest();

            List<Element> oElement = ElementCount.PickObjects(_commandData, BuiltInCategory.OST_PipeCurves);

            TaskDialog.Show("Количество труб", $"Трубы: {oElement.Count} шт.");

            RaiseShowRequest();
        }

        public event EventHandler HideRequest;
        //метод для закрытия окна
        private void RaiseHideRequest()
        {//Для запуска методов привзязанных к запросу закрытия
            HideRequest?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ShowRequest;
        //метод для закрытия окна
        private void RaiseShowRequest()
        {//Для запуска методов привзязанных к запросу закрытия
            ShowRequest?.Invoke(this, EventArgs.Empty);
        }


    }
}

