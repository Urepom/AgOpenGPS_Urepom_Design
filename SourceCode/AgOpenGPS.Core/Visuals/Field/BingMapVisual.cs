using AgOpenGPS.Core.Drawing;
using AgOpenGPS.Core.DrawLib;
using AgOpenGPS.Core.Models;

namespace AgOpenGPS.Core.Visuals
{
    public class BingMapVisual
    {
        private BingMap _bingMap;
        private GeoTexture2D _bingMapTexture;

        public BingMapVisual(BingMap bingMap)
        {
            _bingMap = bingMap;
            _bingMapTexture = new GeoTexture2D(bingMap.Bitmap);
        }

        public void Draw()
        {
            if (_bingMap != null)
            {
                GLW.SetColor(Colors.BingMapBackgroundColor);
                GeoCoord u0v0Map = new GeoCoord(_bingMap.GeoBoundingBox.MinEasting, _bingMap.GeoBoundingBox.MaxNorthing);
                GeoCoord u1v1Map = new GeoCoord(_bingMap.GeoBoundingBox.MaxEasting, _bingMap.GeoBoundingBox.MinNorthing);
                _bingMapTexture.DrawZ(u0v0Map, u1v1Map, -0.05);
            }
        }

    }

}
