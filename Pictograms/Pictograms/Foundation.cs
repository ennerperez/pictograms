using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace System.Drawing.Pictograms
{

    /// <summary>
    /// Foundation Icons - General
    /// <see cref="http://foundation.zurb.com/"/>
    /// </summary>
    public class Foundation : Pictogram
    {

        #region Singleton

        private static Foundation instance;

        /// <summary>
        /// Initializes the <see cref="Icon" /> class by loading the font from resources upon first use.
        /// </summary>
        private Foundation() : base()
        {
        }

        public static Foundation Instance
        {
            get
            {
                if (instance == null)
                    instance = new Foundation();
                return instance;
            }
        }

        #endregion

        /// <summary>
        /// Version 6.0.0
        /// </summary>
        public enum IconType : int
        {

            Settings = 0xf000,
            Heart = 0xf001,
            Star = 0xf002,
            Plus = 0xf003,
            Minus = 0xf004,
            Checkmark = 0xf005,
            Remove = 0xf006,
            Mail = 0xf007,
            Calendar = 0xf008,
            Page = 0xf009,
            Tools = 0xf00a,
            Globe = 0xf00b,
            Home = 0xf00c,
            Quote = 0xf00d,
            People = 0xf00e,
            Monitor = 0xf00f,
            Laptop = 0xf010,
            Phone = 0xf011,
            Cloud = 0xf012,
            Error = 0xf013,
            RightArrow = 0xf014,
            LeftArrow = 0xf015,
            UpArrow = 0xf016,
            DownArrow = 0xf017,
            Trash = 0xf018,
            AddDoc = 0xf019,
            Edit = 0xf01a,
            Lock= 0xf01b,
            Unlock = 0xf01c,
            Refresh = 0xf01d,
            PaperClip = 0xf01e,
            Video = 0xf01f,
            Photo = 0xf020,
            Graph = 0xf021,
            Idea = 0xf022,
            Mic = 0xf023,
            Cart = 0xf024,
            AddressBook = 0xf025,
            Compass = 0xf026,
            Flag = 0xf027,
            Location = 0xf028,
            Clock = 0xf029,
            Folder = 0xf02a,
            Inbox = 0xf02b,
            Website = 0xf02c,
            Smiley = 0xf02d,
            Search = 0xf02e,
        }

    }
}
