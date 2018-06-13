<<<<<<< HEAD:Pictograms/Pictograms/Foundation.cs
﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace System.Drawing.Pictograms
=======
﻿#if !PORTABLE
using System.Drawing.Pictograms.Attributes;
namespace System.Drawing.Pictograms
#else
using Xamarin.Forms.Pictograms.Attributes;
namespace Xamarin.Forms.Pictograms
#endif
>>>>>>> develop:src/Pictograms/Pictograms/Foundation.cs
{

    /// <summary>
    /// Foundation Icons
    /// <see cref="http://zurb.com/playground/foundation-icon-fonts-3"/>
    /// </summary>
    [Pictogram("Foundation", "foundation-icons", "http://zurb.com/playground/uploads/upload/upload/288/foundation-icons.zip")]
    public class Foundation : Pictogram
    {

        #region Singleton

        /// <summary>
        /// Initializes the <see cref="Icon" /> class by loading the font from resources upon first use.
        /// </summary>
        private Foundation() : base(Properties.Resources.foundation_icons)
        {
        }

        public static Foundation Instance
        {
            get
            {
                if (instance == null)
                    instance = new Foundation();
                return (Foundation)instance;
            }
        }

        #endregion

        public Foundation(bool @default) : this()
        {
        }

        #region Statics

        public static Image GetImage(IconType type, int size, Brush brush)
        {
            return Foundation.Instance.GetImage((int)type, size, brush);
        }
        public static Image GetImage(IconType type, int size, Color color)
        {
            return Foundation.Instance.GetImage((int)type, size, color);
        }
        public static Image GetImage(IconType type, int size)
        {
            return Foundation.Instance.GetImage((int)type, size);
        }

        public static string GetText(IconType type)
        {
            return char.ConvertFromUtf32((int)type);
        }

        public static new Font GetFont(float size, GraphicsUnit units = GraphicsUnit.Point)
        {
            return new Font(Foundation.Instance.fonts.Families[0], size, units);
        }

        #endregion

        /// <summary>
        /// Version 3.0.0
        /// </summary>
        public enum IconType : int
        {

            address_book = 0xf100,
            alert = 0xf101,
            align_center = 0xf102,
            align_justify = 0xf103,
            align_left = 0xf104,
            align_right = 0xf105,
            anchor = 0xf106,
            annotate = 0xf107,
            archive = 0xf108,
            arrow_down = 0xf109,
            arrow_left = 0xf10a,
            arrow_right = 0xf10b,
            arrow_up = 0xf10c,
            arrows_compress = 0xf10d,
            arrows_expand = 0xf10e,
            arrows_in = 0xf10f,
            arrows_out = 0xf110,
            asl = 0xf111,
            asterisk = 0xf112,
            at_sign = 0xf113,
            background_color = 0xf114,
            battery_empty = 0xf115,
            battery_full = 0xf116,
            battery_half = 0xf117,
            bitcoin_circle = 0xf118,
            bitcoin = 0xf119,
            blind = 0xf11a,
            bluetooth = 0xf11b,
            bold = 0xf11c,
            book_bookmark = 0xf11d,
            book = 0xf11e,
            bookmark = 0xf11f,
            braille = 0xf120,
            burst_new = 0xf121,
            burst_sale = 0xf122,
            burst = 0xf123,
            calendar = 0xf124,
            camera = 0xf125,
            check = 0xf126,
            checkbox = 0xf127,
            clipboard_notes = 0xf128,
            clipboard_pencil = 0xf129,
            clipboard = 0xf12a,
            clock = 0xf12b,
            closed_caption = 0xf12c,
            cloud = 0xf12d,
            comment_minus = 0xf12e,
            comment_quotes = 0xf12f,
            comment_video = 0xf130,
            comment = 0xf131,
            comments = 0xf132,
            compass = 0xf133,
            contrast = 0xf134,
            credit_card = 0xf135,
            crop = 0xf136,
            crown = 0xf137,
            css3 = 0xf138,
            database = 0xf139,
            die_five = 0xf13a,
            die_four = 0xf13b,
            die_one = 0xf13c,
            die_six = 0xf13d,
            die_three = 0xf13e,
            die_two = 0xf13f,
            dislike = 0xf140,
            dollar_bill = 0xf141,
            dollar = 0xf142,
            download = 0xf143,
            eject = 0xf144,
            elevator = 0xf145,
            euro = 0xf146,
            eye = 0xf147,
            fast_forward = 0xf148,
            female_symbol = 0xf149,
            female = 0xf14a,
            filter = 0xf14b,
            first_aid = 0xf14c,
            flag = 0xf14d,
            folder_add = 0xf14e,
            folder_lock = 0xf14f,
            folder = 0xf150,
            foot = 0xf151,
            foundation = 0xf152,
            graph_bar = 0xf153,
            graph_horizontal = 0xf154,
            graph_pie = 0xf155,
            graph_trend = 0xf156,
            guide_dog = 0xf157,
            hearing_aid = 0xf158,
            heart = 0xf159,
            home = 0xf15a,
            html5 = 0xf15b,
            indent_less = 0xf15c,
            indent_more = 0xf15d,
            info = 0xf15e,
            italic = 0xf15f,
            key = 0xf160,
            laptop = 0xf161,
            layout = 0xf162,
            lightbulb = 0xf163,
            like = 0xf164,
            link = 0xf165,
            list_bullet = 0xf166,
            list_number = 0xf167,
            list_thumbnails = 0xf168,
            list = 0xf169,
            @lock = 0xf16a,
            loop = 0xf16b,
            magnifying_glass = 0xf16c,
            mail = 0xf16d,
            male_female = 0xf16e,
            male_symbol = 0xf16f,
            male = 0xf170,
            map = 0xf171,
            marker = 0xf172,
            megaphone = 0xf173,
            microphone = 0xf174,
            minus_circle = 0xf175,
            minus = 0xf176,
            mobile_signal = 0xf177,
            mobile = 0xf178,
            monitor = 0xf179,
            mountains = 0xf17a,
            music = 0xf17b,
            next = 0xf17c,
            no_dogs = 0xf17d,
            no_smoking = 0xf17e,
            page_add = 0xf17f,
            page_copy = 0xf180,
            page_csv = 0xf181,
            page_delete = 0xf182,
            page_doc = 0xf183,
            page_edit = 0xf184,
            page_export_csv = 0xf185,
            page_export_doc = 0xf186,
            page_export_pdf = 0xf187,
            page_export = 0xf188,
            page_filled = 0xf189,
            page_multiple = 0xf18a,
            page_pdf = 0xf18b,
            page_remove = 0xf18c,
            page_search = 0xf18d,
            page = 0xf18e,
            paint_bucket = 0xf18f,
            paperclip = 0xf190,
            pause = 0xf191,
            paw = 0xf192,
            paypal = 0xf193,
            pencil = 0xf194,
            photo = 0xf195,
            play_circle = 0xf196,
            play_video = 0xf197,
            play = 0xf198,
            plus = 0xf199,
            pound = 0xf19a,
            power = 0xf19b,
            previous = 0xf19c,
            price_tag = 0xf19d,
            pricetag_multiple = 0xf19e,
            print = 0xf19f,
            prohibited = 0xf1a0,
            projection_screen = 0xf1a1,
            puzzle = 0xf1a2,
            quote = 0xf1a3,
            record = 0xf1a4,
            refresh = 0xf1a5,
            results_demographics = 0xf1a6,
            results = 0xf1a7,
            rewind_ten = 0xf1a8,
            rewind = 0xf1a9,
            rss = 0xf1aa,
            safety_cone = 0xf1ab,
            save = 0xf1ac,
            share = 0xf1ad,
            sheriff_badge = 0xf1ae,
            shield = 0xf1af,
            shopping_bag = 0xf1b0,
            shopping_cart = 0xf1b1,
            shuffle = 0xf1b2,
            skull = 0xf1b3,
            social_500px = 0xf1b4,
            social_adobe = 0xf1b5,
            social_amazon = 0xf1b6,
            social_android = 0xf1b7,
            social_apple = 0xf1b8,
            social_behance = 0xf1b9,
            social_bing = 0xf1ba,
            social_blogger = 0xf1bb,
            social_delicious = 0xf1bc,
            social_designer_news = 0xf1bd,
            social_deviant_art = 0xf1be,
            social_digg = 0xf1bf,
            social_dribbble = 0xf1c0,
            social_drive = 0xf1c1,
            social_dropbox = 0xf1c2,
            social_evernote = 0xf1c3,
            social_facebook = 0xf1c4,
            social_flickr = 0xf1c5,
            social_forrst = 0xf1c6,
            social_foursquare = 0xf1c7,
            social_game_center = 0xf1c8,
            social_github = 0xf1c9,
            social_google_plus = 0xf1ca,
            social_hacker_news = 0xf1cb,
            social_hi5 = 0xf1cc,
            social_instagram = 0xf1cd,
            social_joomla = 0xf1ce,
            social_lastfm = 0xf1cf,
            social_linkedin = 0xf1d0,
            social_medium = 0xf1d1,
            social_myspace = 0xf1d2,
            social_orkut = 0xf1d3,
            social_path = 0xf1d4,
            social_picasa = 0xf1d5,
            social_pinterest = 0xf1d6,
            social_rdio = 0xf1d7,
            social_reddit = 0xf1d8,
            social_skillshare = 0xf1d9,
            social_skype = 0xf1da,
            social_smashing_mag = 0xf1db,
            social_snapchat = 0xf1dc,
            social_spotify = 0xf1dd,
            social_squidoo = 0xf1de,
            social_stack_overflow = 0xf1df,
            social_steam = 0xf1e0,
            social_stumbleupon = 0xf1e1,
            social_treehouse = 0xf1e2,
            social_tumblr = 0xf1e3,
            social_twitter = 0xf1e4,
            social_vimeo = 0xf1e5,
            social_windows = 0xf1e6,
            social_xbox = 0xf1e7,
            social_yahoo = 0xf1e8,
            social_yelp = 0xf1e9,
            social_youtube = 0xf1ea,
            social_zerply = 0xf1eb,
            social_zurb = 0xf1ec,
            sound = 0xf1ed,
            star = 0xf1ee,
            stop = 0xf1ef,
            strikethrough = 0xf1f0,
            subscript = 0xf1f1,
            superscript = 0xf1f2,
            tablet_landscape = 0xf1f3,
            tablet_portrait = 0xf1f4,
            target_two = 0xf1f5,
            target = 0xf1f6,
            telephone_accessible = 0xf1f7,
            telephone = 0xf1f8,
            text_color = 0xf1f9,
            thumbnails = 0xf1fa,
            ticket = 0xf1fb,
            torso_business = 0xf1fc,
            torso_female = 0xf1fd,
            torso = 0xf1fe,
            torsos_all_female = 0xf1ff,
            torsos_all = 0xf200,
            torsos_female_male = 0xf201,
            torsos_male_female = 0xf202,
            torsos = 0xf203,
            trash = 0xf204,
            trees = 0xf205,
            trophy = 0xf206,
            underline = 0xf207,
            universal_access = 0xf208,
            unlink = 0xf209,
            unlock = 0xf20a,
            upload_cloud = 0xf20b,
            upload = 0xf20c,
            usb = 0xf20d,
            video = 0xf20e,
            volume_none = 0xf20f,
            volume_strike = 0xf210,
            volume = 0xf211,
            web = 0xf212,
            wheelchair = 0xf213,
            widget = 0xf214,
            wrench = 0xf215,
            x_circle = 0xf216,
            x = 0xf217,
            yen = 0xf218,
            zoom_in = 0xf219,
            zoom_out = 0xf21a
        }

    }
}
