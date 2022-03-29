using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingTsk51
{
    public class VolWallCount
    {
        public static double Volume(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Element> walls = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType()
                .Cast<Element>()
                .ToList();

            double vol = 0;

            foreach (Wall wall in walls)
            {
                if (wall is Wall)
                {

                    double vol1 = wall.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED).AsDouble();
                    double vol2 = UnitUtils.ConvertFromInternalUnits(vol1, UnitTypeId.CubicMeters);
                    vol += vol2;
                }
            }


            return vol;
         
        }
    }
}
