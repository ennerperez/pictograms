#if !PORTABLE

namespace System.Drawing.Pictograms
#else

namespace Xamarin.Forms.Pictograms
#endif
{
    /// <summary>
    /// LinearIcons
    /// <see cref="https://linearicons.com/free"/>
    /// </summary>
    public class LinearIcons : Pictogram
    {
        #region Singleton

        /// <summary>
        /// Initializes the <see cref="Icon" /> class by loading the font from resources upon first use.
        /// </summary>
#if !PORTABLE

        private LinearIcons() : base(Properties.Resources.linearicons_free)
#else

        private LinearIcons() : base()
#endif
        {
        }

        public static LinearIcons Instance
        {
            get
            {
                if (instance == null)
                    instance = new LinearIcons();
                return (LinearIcons)instance;
            }
        }

        #endregion Singleton

        public LinearIcons(bool @default) : this()
        {
        }

        public const string Typeface = "linearicons-free";

#if PORTABLE

        public override string GetFontFace()
        {
            return LinearIcons.Typeface;
        }

#endif

        #region Statics

#if !PORTABLE

        public static Image GetImage(IconType type, int size, Brush brush)
        {
            return LinearIcons.Instance.GetImage((int)type, size, brush);
        }

        public static Image GetImage(IconType type, int size, Color color)
        {
            return LinearIcons.Instance.GetImage((int)type, size, color);
        }

        public static Image GetImage(IconType type, int size)
        {
            return LinearIcons.Instance.GetImage((int)type, size);
        }

#endif

        public static string GetText(IconType type)
        {
            return char.ConvertFromUtf32((int)type);
        }

#if !PORTABLE

        public static new Font GetFont(float size, GraphicsUnit units = GraphicsUnit.Point)
        {
            return new Font(LinearIcons.Instance.fonts.Families[0], size, units);
        }

#endif

        #endregion Statics

        /// <summary>
        /// Version 1.0.0
        /// </summary>
        public enum IconType : int
        {
            home = 0xe800,
            apartment = 0xe801,
            pencil = 0xe802,
            magic_wand = 0xe803,
            drop = 0xe804,
            lighter = 0xe805,
            poop = 0xe806,
            sun = 0xe807,
            moon = 0xe808,
            cloud = 0xe809,
            cloud_upload = 0xe80a,
            cloud_download = 0xe80b,
            cloud_sync = 0xe80c,
            cloud_check = 0xe80d,
            database = 0xe80e,
            @lock = 0xe80f,
            cog = 0xe810,
            trash = 0xe811,
            dice = 0xe812,
            heart = 0xe813,
            star = 0xe814,
            star_half = 0xe815,
            star_empty = 0xe816,
            flag = 0xe817,
            envelope = 0xe818,
            paperclip = 0xe819,
            inbox = 0xe81a,
            eye = 0xe81b,
            printer = 0xe81c,
            file_empty = 0xe81d,
            file_add = 0xe81e,
            enter = 0xe81f,
            exit = 0xe820,
            graduation_hat = 0xe821,
            license = 0xe822,
            music_note = 0xe823,
            film_play = 0xe824,
            camera_video = 0xe825,
            camera = 0xe826,
            picture = 0xe827,
            book = 0xe828,
            bookmark = 0xe829,
            user = 0xe82a,
            users = 0xe82b,
            shirt = 0xe82c,
            store = 0xe82d,
            cart = 0xe82e,
            tag = 0xe82f,
            phone_handset = 0xe830,
            phone = 0xe831,
            pushpin = 0xe832,
            map_marker = 0xe833,
            map = 0xe834,
            location = 0xe835,
            calendar_full = 0xe836,
            keyboard = 0xe837,
            spell_check = 0xe838,
            screen = 0xe839,
            smartphone = 0xe83a,
            tablet = 0xe83b,
            laptop = 0xe83c,
            laptop_phone = 0xe83d,
            power_switch = 0xe83e,
            bubble = 0xe83f,
            heart_pulse = 0xe840,
            construction = 0xe841,
            pie_chart = 0xe842,
            chart_bars = 0xe843,
            gift = 0xe844,
            diamond = 0xe845,
            linearicons = 0xe846,
            dinner = 0xe847,
            coffee_cup = 0xe848,
            leaf = 0xe849,
            paw = 0xe84a,
            rocket = 0xe84b,
            briefcase = 0xe84c,
            bus = 0xe84d,
            car = 0xe84e,
            train = 0xe84f,
            bicycle = 0xe850,
            wheelchair = 0xe851,
            select = 0xe852,
            earth = 0xe853,
            smile = 0xe854,
            sad = 0xe855,
            neutral = 0xe856,
            mustache = 0xe857,
            alarm = 0xe858,
            bullhorn = 0xe859,
            volume_high = 0xe85a,
            volume_medium = 0xe85b,
            volume_low = 0xe85c,
            volume = 0xe85d,
            mic = 0xe85e,
            hourglass = 0xe85f,
            undo = 0xe860,
            redo = 0xe861,
            sync = 0xe862,
            history = 0xe863,
            clock = 0xe864,
            download = 0xe865,
            upload = 0xe866,
            enter_down = 0xe867,
            exit_up = 0xe868,
            bug = 0xe869,
            code = 0xe86a,
            link = 0xe86b,
            unlink = 0xe86c,
            thumbs_up = 0xe86d,
            thumbs_down = 0xe86e,
            magnifier = 0xe86f,
            cross = 0xe870,
            menu = 0xe871,
            list = 0xe872,
            chevron_up = 0xe873,
            chevron_down = 0xe874,
            chevron_left = 0xe875,
            chevron_right = 0xe876,
            arrow_up = 0xe877,
            arrow_down = 0xe878,
            arrow_left = 0xe879,
            arrow_right = 0xe87a,
            move = 0xe87b,
            warning = 0xe87c,
            question_circle = 0xe87d,
            menu_circle = 0xe87e,
            checkmark_circle = 0xe87f,
            cross_circle = 0xe880,
            plus_circle = 0xe881,
            circle_minus = 0xe882,
            arrow_up_circle = 0xe883,
            arrow_down_circle = 0xe884,
            arrow_left_circle = 0xe885,
            arrow_right_circle = 0xe886,
            chevron_up_circle = 0xe887,
            chevron_down_circle = 0xe888,
            chevron_left_circle = 0xe889,
            chevron_right_circle = 0xe88a,
            crop = 0xe88b,
            frame_expand = 0xe88c,
            frame_contract = 0xe88d,
            layers = 0xe88e,
            funnel = 0xe88f,
            text_format = 0xe890,
            text_format_remove = 0xe891,
            text_size = 0xe892,
            bold = 0xe893,
            italic = 0xe894,
            underline = 0xe895,
            strikethrough = 0xe896,
            highlight = 0xe897,
            text_align_left = 0xe898,
            text_align_center = 0xe899,
            text_align_right = 0xe89a,
            text_align_justify = 0xe89b,
            line_spacing = 0xe89c,
            indent_increase = 0xe89d,
            indent_decrease = 0xe89e,
            pilcrow = 0xe89f,
            direction_ltr = 0xe8a0,
            direction_rtl = 0xe8a1,
            page_break = 0xe8a2,
            sort_alpha_asc = 0xe8a3,
            sort_amount_asc = 0xe8a4,
            hand = 0xe8a5,
            pointer_up = 0xe8a6,
            pointer_right = 0xe8a7,
            pointer_down = 0xe8a8,
            pointer_left = 0xe8a9
        }
    }
}