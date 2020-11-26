using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using Virinco.WATS.Interface;
using System.IO;

namespace ListenincConverters
{
    [TestClass]
    public class ConverterTests : TDM
    {
        [TestMethod]
        public void SetupClient()
        {
            SetupAPI(null, "Drammen, Norway", "Demo", true);
            RegisterClient("https://listen.skywats.com", "", "cmVnaXN0ZXJDbGllbnRUb2tlbjp0OHQzZXpycXJscGEzMTR3dHNydTJy");
            InitializeAPI(true);
        }

        [TestMethod]
        public void TestSoundCheckConverter()
        {
            InitializeAPI(true);
            SoundCheckConverter converter = new SoundCheckConverter();
            using (FileStream file = new FileStream("Data\\WATS18 11-2-2020.txt", FileMode.Open))
            {
                Report uut = converter.ImportReport(this, file);
                Submit(uut);
            }
        }
    }
}
