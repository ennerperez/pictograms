using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace System.Drawing.Pictograms
{

    /// <summary>
    /// LinearIcons
    /// <see cref="https://linearicons.com/free"/>
    /// </summary>   
    public class LinearIcons : Pictogram
    {

        #region Singleton

        private static LinearIcons instance;

        /// <summary>
        /// Initializes the <see cref="Icon" /> class by loading the font from resources upon first use.
        /// </summary>
        private LinearIcons() : base()
        {
        }

        public static LinearIcons Instance
        {
            get
            {
                if (instance == null)
                    instance = new LinearIcons();
                return instance;
            }
        }

        #endregion

        /// <summary>
        /// Version 1.0.0
        /// </summary>
        public enum IconType : int
        {
            alarm = 0xe858,
            apartment = 0xe801,
            arrowdown = 0xe878,
            arrowdowncircle = 0xe884,
            arrowleft = 0xe879,
            arrowleftcircle = 0xe885,
            arrowright = 0xe87a,
            arrowrightcircle = 0xe886,
            arrowup = 0xe877,
            arrowupcircle = 0xe883,
            bicycle = 0xe850,
            bold = 0xe893,
            book = 0xe828,
            bookmark = 0xe829,
            briefcase = 0xe84c,
            bubble = 0xe83f,
            bug = 0xe869,
            bullhorn = 0xe859,
            bus = 0xe84d,
            calendarfull = 0xe836,
            camera = 0xe826,
            cameravideo = 0xe825,
            car = 0xe84e,
            cart = 0xe82e,
            chartbars = 0xe843,
            checkmarkcircle = 0xe87f,
            chevrondown = 0xe874,
            chevrondowncircle = 0xe888,
            chevronleft = 0xe875,
            chevronleftcircle = 0xe889,
            chevronright = 0xe876,
            chevronrightcircle = 0xe88a,
            chevronup = 0xe873,
            chevronupcircle = 0xe887,
            circleminus = 0xe882,
            clock = 0xe864,
            cloud = 0xe809,
            cloudcheck = 0xe80d,
            clouddownload = 0xe80b,
            cloudsync = 0xe80c,
            cloudupload = 0xe80a,
            code = 0xe86a,
            coffeecup = 0xe848,
            cog = 0xe810,
            construction = 0xe841,
            crop = 0xe88b,
            cross = 0xe870,
            crosscircle = 0xe880,
            database = 0xe80e,
            diamond = 0xe845,
            dice = 0xe812,
            dinner = 0xe847,
            directionltr = 0xe8a0,
            directionrtl = 0xe8a1,
            download = 0xe865,
            drop = 0xe804,
            earth = 0xe853,
            enter = 0xe81f,
            enterdown = 0xe867,
            envelope = 0xe818,
            exit = 0xe820,
            exitup = 0xe868,
            eye = 0xe81b,
            fileadd = 0xe81e,
            fileempty = 0xe81d,
            filmplay = 0xe824,
            flag = 0xe817,
            framecontract = 0xe88d,
            frameexpand = 0xe88c,
            funnel = 0xe88f,
            gift = 0xe844,
            graduationhat = 0xe821,
            hand = 0xe8a5,
            heart = 0xe813,
            heartpulse = 0xe840,
            highlight = 0xe897,
            history = 0xe863,
            home = 0xe800,
            hourglass = 0xe85f,
            inbox = 0xe81a,
            indentdecrease = 0xe89e,
            indentincrease = 0xe89d,
            italic = 0xe894,
            keyboard = 0xe837,
            laptop = 0xe83c,
            laptopphone = 0xe83d,
            layers = 0xe88e,
            leaf = 0xe849,
            license = 0xe822,
            lighter = 0xe805,
            linearicons = 0xe846,
            linespacing = 0xe89c,
            link = 0xe86b,
            list = 0xe872,
            location = 0xe835,
            @lock = 0xe80f,
            magicwand = 0xe803,
            magnifier = 0xe86f,
            map = 0xe834,
            mapmarker = 0xe833,
            menu = 0xe871,
            menucircle = 0xe87e,
            mic = 0xe85e,
            moon = 0xe808,
            move = 0xe87b,
            musicnote = 0xe823,
            mustache = 0xe857,
            neutral = 0xe856,
            pagebreak = 0xe8a2,
            paperclip = 0xe819,
            paw = 0xe84a,
            pencil = 0xe802,
            phone = 0xe831,
            phonehandset = 0xe830,
            picture = 0xe827,
            piechart = 0xe842,
            pilcrow = 0xe89f,
            pluscircle = 0xe881,
            pointerdown = 0xe8a8,
            pointerleft = 0xe8a9,
            pointerright = 0xe8a7,
            pointerup = 0xe8a6,
            poop = 0xe806,
            powerswitch = 0xe83e,
            printer = 0xe81c,
            pushpin = 0xe832,
            questioncircle = 0xe87d,
            redo = 0xe861,
            rocket = 0xe84b,
            sad = 0xe855,
            screen = 0xe839,
            select = 0xe852,
            shirt = 0xe82c,
            smartphone = 0xe83a,
            smile = 0xe854,
            sortalphaasc = 0xe8a3,
            sortamountasc = 0xe8a4,
            spellcheck = 0xe838,
            star = 0xe814,
            starempty = 0xe816,
            starhalf = 0xe815,
            store = 0xe82d,
            strikethrough = 0xe896,
            sun = 0xe807,
            sync = 0xe862,
            tablet = 0xe83b,
            tag = 0xe82f,
            textaligncenter = 0xe899,
            textalignjustify = 0xe89b,
            textalignleft = 0xe898,
            textalignright = 0xe89a,
            textformat = 0xe890,
            textformatremove = 0xe891,
            textsize = 0xe892,
            thumbsdown = 0xe86e,
            thumbsup = 0xe86d,
            train = 0xe84f,
            trash = 0xe811,
            underline = 0xe895,
            undo = 0xe860,
            unlink = 0xe86c,
            upload = 0xe866,
            user = 0xe82a,
            users = 0xe82b,
            volume = 0xe85d,
            volumehigh = 0xe85a,
            volumelow = 0xe85c,
            volumemedium = 0xe85b,
            warning = 0xe87c,
            wheelchair = 0xe851
        }

    }
}
