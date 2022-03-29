using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingTsk51
{
    public class ElementCount
    {
        public static List<Element> PickObjects(ExternalCommandData commandData, BuiltInCategory category, string message = "Выберете элементы")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            //для распаковки элемента
            Document doc = uidoc.Document;


            ////переменная для выбора объекта
            //var selectedObjects = uidoc.Selection.PickObjects(ObjectType.Element, message);
            //Преобразование в лист с  элементами
            List<Element> elementList = new FilteredElementCollector(doc)
                .OfCategory(category)
                .WhereElementIsNotElementType()
                .Cast<Element>()
                .ToList();
            //List<Element> elementList = selectedObjects.Select(selectedObject => doc.GetElement(selectedObject)).ToList();
            return elementList;
        }
    }
}