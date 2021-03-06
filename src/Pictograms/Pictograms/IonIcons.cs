﻿#if !PORTABLE

using System.Drawing.Pictograms.Attributes;

namespace System.Drawing.Pictograms
#else

using Xamarin.Forms.Pictograms.Attributes;

namespace Xamarin.Forms.Pictograms
#endif
{
    /// <summary>
    /// Ionic
    /// <see cref="http://ionicons.com/"/>
    /// </summary>
    [Pictogram("IonIcons", "ionicons", "https://github.com/driftyco/ionicons/archive/v4.5.10-1.zip")]
    public class IonIcons : Pictogram
    {
        #region Singleton

        /// <summary>
        /// Initializes the <see cref="Icon" /> class by loading the font from resources upon first use.
        /// </summary>
#if !PORTABLE

        private IonIcons() : base(Properties.Resources.ionicons)
#else

        private IonIcons() : base()
#endif
        {
        }

        internal static IonIcons instance;

        public static IonIcons Instance
        {
            get
            {
                if (instance == null)
                    instance = new IonIcons();
                return (IonIcons)instance;
            }
        }

        #endregion Singleton

        public IonIcons(bool @default) : this()
        {
        }

        #region Statics

#if !PORTABLE

        public static Image GetImage(IconType type, int size, Brush brush)
        {
            return IonIcons.Instance.GetImage((int)type, size, brush);
        }

        public static Image GetImage(IconType type, int size, Color color)
        {
            return IonIcons.Instance.GetImage((int)type, size, color);
        }

        public static Image GetImage(IconType type, int size)
        {
            return IonIcons.Instance.GetImage((int)type, size);
        }

#endif

        public static string GetText(IconType type)
        {
            return char.ConvertFromUtf32((int)type);
        }

#if !PORTABLE

        public static new Font GetFont(float size, GraphicsUnit units = GraphicsUnit.Point)
        {
            return new Font(IonIcons.Instance.fonts.Families[0], size, units);
        }

#endif

        #endregion Statics

        /// <summary>
        /// Version 4.5.10
        /// </summary>
        public enum IconType : int
        {
            ios_add = 0xf102,
            ios_add_circle = 0xf101,
            ios_add_circle_outline = 0xf100,
            ios_airplane = 0xf137,
            ios_alarm = 0xf3c8,
            ios_albums = 0xf3ca,
            ios_alert = 0xf104,
            ios_american_football = 0xf106,
            ios_analytics = 0xf3ce,
            ios_aperture = 0xf108,
            ios_apps = 0xf10a,
            ios_appstore = 0xf10c,
            ios_archive = 0xf10e,
            ios_arrow_back = 0xf3cf,
            ios_arrow_down = 0xf3d0,
            ios_arrow_dropdown = 0xf110,
            ios_arrow_dropdown_circle = 0xf125,
            ios_arrow_dropleft = 0xf112,
            ios_arrow_dropleft_circle = 0xf129,
            ios_arrow_dropright = 0xf114,
            ios_arrow_dropright_circle = 0xf12b,
            ios_arrow_dropup = 0xf116,
            ios_arrow_dropup_circle = 0xf12d,
            ios_arrow_forward = 0xf3d1,
            ios_arrow_round_back = 0xf117,
            ios_arrow_round_down = 0xf118,
            ios_arrow_round_forward = 0xf119,
            ios_arrow_round_up = 0xf11a,
            ios_arrow_up = 0xf3d8,
            ios_at = 0xf3da,
            ios_attach = 0xf11b,
            ios_backspace = 0xf11d,
            ios_barcode = 0xf3dc,
            ios_baseball = 0xf3de,
            ios_basket = 0xf11f,
            ios_basketball = 0xf3e0,
            ios_battery_charging = 0xf120,
            ios_battery_dead = 0xf121,
            ios_battery_full = 0xf122,
            ios_beaker = 0xf124,
            ios_bed = 0xf139,
            ios_beer = 0xf126,
            ios_bicycle = 0xf127,
            ios_bluetooth = 0xf128,
            ios_boat = 0xf12a,
            ios_body = 0xf3e4,
            ios_bonfire = 0xf12c,
            ios_book = 0xf3e8,
            ios_bookmark = 0xf12e,
            ios_bookmarks = 0xf3ea,
            ios_bowtie = 0xf130,
            ios_briefcase = 0xf3ee,
            ios_browsers = 0xf3f0,
            ios_brush = 0xf132,
            ios_bug = 0xf134,
            ios_build = 0xf136,
            ios_bulb = 0xf138,
            ios_bus = 0xf13a,
            ios_business = 0xf1a3,
            ios_cafe = 0xf13c,
            ios_calculator = 0xf3f2,
            ios_calendar = 0xf3f4,
            ios_call = 0xf13e,
            ios_camera = 0xf3f6,
            ios_car = 0xf140,
            ios_card = 0xf142,
            ios_cart = 0xf3f8,
            ios_cash = 0xf144,
            ios_cellular = 0xf13d,
            ios_chatboxes = 0xf3fa,
            ios_chatbubbles = 0xf146,
            ios_checkbox = 0xf148,
            ios_checkbox_outline = 0xf147,
            ios_checkmark = 0xf3ff,
            ios_checkmark_circle = 0xf14a,
            ios_checkmark_circle_outline = 0xf149,
            ios_clipboard = 0xf14c,
            ios_clock = 0xf403,
            ios_close = 0xf406,
            ios_close_circle = 0xf14e,
            ios_close_circle_outline = 0xf14d,
            ios_cloud = 0xf40c,
            ios_cloud_circle = 0xf152,
            ios_cloud_done = 0xf154,
            ios_cloud_download = 0xf408,
            ios_cloud_outline = 0xf409,
            ios_cloud_upload = 0xf40b,
            ios_cloudy = 0xf410,
            ios_cloudy_night = 0xf40e,
            ios_code = 0xf157,
            ios_code_download = 0xf155,
            ios_code_working = 0xf156,
            ios_cog = 0xf412,
            ios_color_fill = 0xf159,
            ios_color_filter = 0xf414,
            ios_color_palette = 0xf15b,
            ios_color_wand = 0xf416,
            ios_compass = 0xf15d,
            ios_construct = 0xf15f,
            ios_contact = 0xf41a,
            ios_contacts = 0xf161,
            ios_contract = 0xf162,
            ios_contrast = 0xf163,
            ios_copy = 0xf41c,
            ios_create = 0xf165,
            ios_crop = 0xf41e,
            ios_cube = 0xf168,
            ios_cut = 0xf16a,
            ios_desktop = 0xf16c,
            ios_disc = 0xf16e,
            ios_document = 0xf170,
            ios_done_all = 0xf171,
            ios_download = 0xf420,
            ios_easel = 0xf173,
            ios_egg = 0xf175,
            ios_exit = 0xf177,
            ios_expand = 0xf178,
            ios_eye = 0xf425,
            ios_eye_off = 0xf17a,
            ios_fastforward = 0xf427,
            ios_female = 0xf17b,
            ios_filing = 0xf429,
            ios_film = 0xf42b,
            ios_finger_print = 0xf17c,
            ios_fitness = 0xf1ab,
            ios_flag = 0xf42d,
            ios_flame = 0xf42f,
            ios_flash = 0xf17e,
            ios_flash_off = 0xf12f,
            ios_flashlight = 0xf141,
            ios_flask = 0xf431,
            ios_flower = 0xf433,
            ios_folder = 0xf435,
            ios_folder_open = 0xf180,
            ios_football = 0xf437,
            ios_funnel = 0xf182,
            ios_gift = 0xf191,
            ios_git_branch = 0xf183,
            ios_git_commit = 0xf184,
            ios_git_compare = 0xf185,
            ios_git_merge = 0xf186,
            ios_git_network = 0xf187,
            ios_git_pull_request = 0xf188,
            ios_glasses = 0xf43f,
            ios_globe = 0xf18a,
            ios_grid = 0xf18c,
            ios_hammer = 0xf18e,
            ios_hand = 0xf190,
            ios_happy = 0xf192,
            ios_headset = 0xf194,
            ios_heart = 0xf443,
            ios_heart_dislike = 0xf13f,
            ios_heart_empty = 0xf19b,
            ios_heart_half = 0xf19d,
            ios_help = 0xf446,
            ios_help_buoy = 0xf196,
            ios_help_circle = 0xf198,
            ios_help_circle_outline = 0xf197,
            ios_home = 0xf448,
            ios_hourglass = 0xf103,
            ios_ice_cream = 0xf19a,
            ios_image = 0xf19c,
            ios_images = 0xf19e,
            ios_infinite = 0xf44a,
            ios_information = 0xf44d,
            ios_information_circle = 0xf1a0,
            ios_information_circle_outline = 0xf19f,
            ios_jet = 0xf1a5,
            ios_journal = 0xf189,
            ios_key = 0xf1a7,
            ios_keypad = 0xf450,
            ios_laptop = 0xf1a8,
            ios_leaf = 0xf1aa,
            ios_link = 0xf22a,
            ios_list = 0xf454,
            ios_list_box = 0xf143,
            ios_locate = 0xf1ae,
            ios_lock = 0xf1b0,
            ios_log_in = 0xf1b1,
            ios_log_out = 0xf1b2,
            ios_magnet = 0xf1b4,
            ios_mail = 0xf1b8,
            ios_mail_open = 0xf1b6,
            ios_mail_unread = 0xf145,
            ios_male = 0xf1b9,
            ios_man = 0xf1bb,
            ios_map = 0xf1bd,
            ios_medal = 0xf1bf,
            ios_medical = 0xf45c,
            ios_medkit = 0xf45e,
            ios_megaphone = 0xf1c1,
            ios_menu = 0xf1c3,
            ios_mic = 0xf461,
            ios_mic_off = 0xf45f,
            ios_microphone = 0xf1c6,
            ios_moon = 0xf468,
            ios_more = 0xf1c8,
            ios_move = 0xf1cb,
            ios_musical_note = 0xf46b,
            ios_musical_notes = 0xf46c,
            ios_navigate = 0xf46e,
            ios_notifications = 0xf1d3,
            ios_notifications_off = 0xf1d1,
            ios_notifications_outline = 0xf133,
            ios_nuclear = 0xf1d5,
            ios_nutrition = 0xf470,
            ios_open = 0xf1d7,
            ios_options = 0xf1d9,
            ios_outlet = 0xf1db,
            ios_paper = 0xf472,
            ios_paper_plane = 0xf1dd,
            ios_partly_sunny = 0xf1df,
            ios_pause = 0xf478,
            ios_paw = 0xf47a,
            ios_people = 0xf47c,
            ios_person = 0xf47e,
            ios_person_add = 0xf1e1,
            ios_phone_landscape = 0xf1e2,
            ios_phone_portrait = 0xf1e3,
            ios_photos = 0xf482,
            ios_pie = 0xf484,
            ios_pin = 0xf1e5,
            ios_pint = 0xf486,
            ios_pizza = 0xf1e7,
            ios_planet = 0xf1eb,
            ios_play = 0xf488,
            ios_play_circle = 0xf113,
            ios_podium = 0xf1ed,
            ios_power = 0xf1ef,
            ios_pricetag = 0xf48d,
            ios_pricetags = 0xf48f,
            ios_print = 0xf1f1,
            ios_pulse = 0xf493,
            ios_qr_scanner = 0xf1f3,
            ios_quote = 0xf1f5,
            ios_radio = 0xf1f9,
            ios_radio_button_off = 0xf1f6,
            ios_radio_button_on = 0xf1f7,
            ios_rainy = 0xf495,
            ios_recording = 0xf497,
            ios_redo = 0xf499,
            ios_refresh = 0xf49c,
            ios_refresh_circle = 0xf135,
            ios_remove = 0xf1fc,
            ios_remove_circle = 0xf1fb,
            ios_remove_circle_outline = 0xf1fa,
            ios_reorder = 0xf1fd,
            ios_repeat = 0xf1fe,
            ios_resize = 0xf1ff,
            ios_restaurant = 0xf201,
            ios_return_left = 0xf202,
            ios_return_right = 0xf203,
            ios_reverse_camera = 0xf49f,
            ios_rewind = 0xf4a1,
            ios_ribbon = 0xf205,
            ios_rocket = 0xf14b,
            ios_rose = 0xf4a3,
            ios_sad = 0xf207,
            ios_save = 0xf1a6,
            ios_school = 0xf209,
            ios_search = 0xf4a5,
            ios_send = 0xf20c,
            ios_settings = 0xf4a7,
            ios_share = 0xf211,
            ios_share_alt = 0xf20f,
            ios_shirt = 0xf213,
            ios_shuffle = 0xf4a9,
            ios_skip_backward = 0xf215,
            ios_skip_forward = 0xf217,
            ios_snow = 0xf218,
            ios_speedometer = 0xf4b0,
            ios_square = 0xf21a,
            ios_square_outline = 0xf15c,
            ios_star = 0xf4b3,
            ios_star_half = 0xf4b1,
            ios_star_outline = 0xf4b2,
            ios_stats = 0xf21c,
            ios_stopwatch = 0xf4b5,
            ios_subway = 0xf21e,
            ios_sunny = 0xf4b7,
            ios_swap = 0xf21f,
            ios_switch = 0xf221,
            ios_sync = 0xf222,
            ios_tablet_landscape = 0xf223,
            ios_tablet_portrait = 0xf24e,
            ios_tennisball = 0xf4bb,
            ios_text = 0xf250,
            ios_thermometer = 0xf252,
            ios_thumbs_down = 0xf254,
            ios_thumbs_up = 0xf256,
            ios_thunderstorm = 0xf4bd,
            ios_time = 0xf4bf,
            ios_timer = 0xf4c1,
            ios_today = 0xf14f,
            ios_train = 0xf258,
            ios_transgender = 0xf259,
            ios_trash = 0xf4c5,
            ios_trending_down = 0xf25a,
            ios_trending_up = 0xf25b,
            ios_trophy = 0xf25d,
            ios_tv = 0xf115,
            ios_umbrella = 0xf25f,
            ios_undo = 0xf4c7,
            ios_unlock = 0xf261,
            ios_videocam = 0xf4cd,
            ios_volume_high = 0xf11c,
            ios_volume_low = 0xf11e,
            ios_volume_mute = 0xf263,
            ios_volume_off = 0xf264,
            ios_walk = 0xf266,
            ios_wallet = 0xf18b,
            ios_warning = 0xf268,
            ios_watch = 0xf269,
            ios_water = 0xf26b,
            ios_wifi = 0xf26d,
            ios_wine = 0xf26f,
            ios_woman = 0xf271,
            logo_android = 0xf225,
            logo_angular = 0xf227,
            logo_apple = 0xf229,
            logo_bitbucket = 0xf193,
            logo_bitcoin = 0xf22b,
            logo_buffer = 0xf22d,
            logo_chrome = 0xf22f,
            logo_closed_captioning = 0xf105,
            logo_codepen = 0xf230,
            logo_css3 = 0xf231,
            logo_designernews = 0xf232,
            logo_dribbble = 0xf233,
            logo_dropbox = 0xf234,
            logo_euro = 0xf235,
            logo_facebook = 0xf236,
            logo_flickr = 0xf107,
            logo_foursquare = 0xf237,
            logo_freebsd_devil = 0xf238,
            logo_game_controller_a = 0xf13b,
            logo_game_controller_b = 0xf181,
            logo_github = 0xf239,
            logo_google = 0xf23a,
            logo_googleplus = 0xf23b,
            logo_hackernews = 0xf23c,
            logo_html5 = 0xf23d,
            logo_instagram = 0xf23e,
            logo_ionic = 0xf150,
            logo_ionitron = 0xf151,
            logo_javascript = 0xf23f,
            logo_linkedin = 0xf240,
            logo_markdown = 0xf241,
            logo_model_s = 0xf153,
            logo_no_smoking = 0xf109,
            logo_nodejs = 0xf242,
            logo_npm = 0xf195,
            logo_octocat = 0xf243,
            logo_pinterest = 0xf244,
            logo_playstation = 0xf245,
            logo_polymer = 0xf15e,
            logo_python = 0xf246,
            logo_reddit = 0xf247,
            logo_rss = 0xf248,
            logo_sass = 0xf249,
            logo_skype = 0xf24a,
            logo_slack = 0xf10b,
            logo_snapchat = 0xf24b,
            logo_steam = 0xf24c,
            logo_tumblr = 0xf24d,
            logo_tux = 0xf2ae,
            logo_twitch = 0xf2af,
            logo_twitter = 0xf2b0,
            logo_usd = 0xf2b1,
            logo_vimeo = 0xf2c4,
            logo_vk = 0xf10d,
            logo_whatsapp = 0xf2c5,
            logo_windows = 0xf32f,
            logo_wordpress = 0xf330,
            logo_xbox = 0xf34c,
            logo_xing = 0xf10f,
            logo_yahoo = 0xf34d,
            logo_yen = 0xf34e,
            logo_youtube = 0xf34f,
            md_add = 0xf273,
            md_add_circle = 0xf272,
            md_add_circle_outline = 0xf158,
            md_airplane = 0xf15a,
            md_alarm = 0xf274,
            md_albums = 0xf275,
            md_alert = 0xf276,
            md_american_football = 0xf277,
            md_analytics = 0xf278,
            md_aperture = 0xf279,
            md_apps = 0xf27a,
            md_appstore = 0xf27b,
            md_archive = 0xf27c,
            md_arrow_back = 0xf27d,
            md_arrow_down = 0xf27e,
            md_arrow_dropdown = 0xf280,
            md_arrow_dropdown_circle = 0xf27f,
            md_arrow_dropleft = 0xf282,
            md_arrow_dropleft_circle = 0xf281,
            md_arrow_dropright = 0xf284,
            md_arrow_dropright_circle = 0xf283,
            md_arrow_dropup = 0xf286,
            md_arrow_dropup_circle = 0xf285,
            md_arrow_forward = 0xf287,
            md_arrow_round_back = 0xf288,
            md_arrow_round_down = 0xf289,
            md_arrow_round_forward = 0xf28a,
            md_arrow_round_up = 0xf28b,
            md_arrow_up = 0xf28c,
            md_at = 0xf28d,
            md_attach = 0xf28e,
            md_backspace = 0xf28f,
            md_barcode = 0xf290,
            md_baseball = 0xf291,
            md_basket = 0xf292,
            md_basketball = 0xf293,
            md_battery_charging = 0xf294,
            md_battery_dead = 0xf295,
            md_battery_full = 0xf296,
            md_beaker = 0xf297,
            md_bed = 0xf160,
            md_beer = 0xf298,
            md_bicycle = 0xf299,
            md_bluetooth = 0xf29a,
            md_boat = 0xf29b,
            md_body = 0xf29c,
            md_bonfire = 0xf29d,
            md_book = 0xf29e,
            md_bookmark = 0xf29f,
            md_bookmarks = 0xf2a0,
            md_bowtie = 0xf2a1,
            md_briefcase = 0xf2a2,
            md_browsers = 0xf2a3,
            md_brush = 0xf2a4,
            md_bug = 0xf2a5,
            md_build = 0xf2a6,
            md_bulb = 0xf2a7,
            md_bus = 0xf2a8,
            md_business = 0xf1a4,
            md_cafe = 0xf2a9,
            md_calculator = 0xf2aa,
            md_calendar = 0xf2ab,
            md_call = 0xf2ac,
            md_camera = 0xf2ad,
            md_car = 0xf2b2,
            md_card = 0xf2b3,
            md_cart = 0xf2b4,
            md_cash = 0xf2b5,
            md_cellular = 0xf164,
            md_chatboxes = 0xf2b6,
            md_chatbubbles = 0xf2b7,
            md_checkbox = 0xf2b9,
            md_checkbox_outline = 0xf2b8,
            md_checkmark = 0xf2bc,
            md_checkmark_circle = 0xf2bb,
            md_checkmark_circle_outline = 0xf2ba,
            md_clipboard = 0xf2bd,
            md_clock = 0xf2be,
            md_close = 0xf2c0,
            md_close_circle = 0xf2bf,
            md_close_circle_outline = 0xf166,
            md_cloud = 0xf2c9,
            md_cloud_circle = 0xf2c2,
            md_cloud_done = 0xf2c3,
            md_cloud_download = 0xf2c6,
            md_cloud_outline = 0xf2c7,
            md_cloud_upload = 0xf2c8,
            md_cloudy = 0xf2cb,
            md_cloudy_night = 0xf2ca,
            md_code = 0xf2ce,
            md_code_download = 0xf2cc,
            md_code_working = 0xf2cd,
            md_cog = 0xf2cf,
            md_color_fill = 0xf2d0,
            md_color_filter = 0xf2d1,
            md_color_palette = 0xf2d2,
            md_color_wand = 0xf2d3,
            md_compass = 0xf2d4,
            md_construct = 0xf2d5,
            md_contact = 0xf2d6,
            md_contacts = 0xf2d7,
            md_contract = 0xf2d8,
            md_contrast = 0xf2d9,
            md_copy = 0xf2da,
            md_create = 0xf2db,
            md_crop = 0xf2dc,
            md_cube = 0xf2dd,
            md_cut = 0xf2de,
            md_desktop = 0xf2df,
            md_disc = 0xf2e0,
            md_document = 0xf2e1,
            md_done_all = 0xf2e2,
            md_download = 0xf2e3,
            md_easel = 0xf2e4,
            md_egg = 0xf2e5,
            md_exit = 0xf2e6,
            md_expand = 0xf2e7,
            md_eye = 0xf2e9,
            md_eye_off = 0xf2e8,
            md_fastforward = 0xf2ea,
            md_female = 0xf2eb,
            md_filing = 0xf2ec,
            md_film = 0xf2ed,
            md_finger_print = 0xf2ee,
            md_fitness = 0xf1ac,
            md_flag = 0xf2ef,
            md_flame = 0xf2f0,
            md_flash = 0xf2f1,
            md_flash_off = 0xf169,
            md_flashlight = 0xf16b,
            md_flask = 0xf2f2,
            md_flower = 0xf2f3,
            md_folder = 0xf2f5,
            md_folder_open = 0xf2f4,
            md_football = 0xf2f6,
            md_funnel = 0xf2f7,
            md_gift = 0xf199,
            md_git_branch = 0xf2fa,
            md_git_commit = 0xf2fb,
            md_git_compare = 0xf2fc,
            md_git_merge = 0xf2fd,
            md_git_network = 0xf2fe,
            md_git_pull_request = 0xf2ff,
            md_glasses = 0xf300,
            md_globe = 0xf301,
            md_grid = 0xf302,
            md_hammer = 0xf303,
            md_hand = 0xf304,
            md_happy = 0xf305,
            md_headset = 0xf306,
            md_heart = 0xf308,
            md_heart_dislike = 0xf167,
            md_heart_empty = 0xf1a1,
            md_heart_half = 0xf1a2,
            md_help = 0xf30b,
            md_help_buoy = 0xf309,
            md_help_circle = 0xf30a,
            md_help_circle_outline = 0xf16d,
            md_home = 0xf30c,
            md_hourglass = 0xf111,
            md_ice_cream = 0xf30d,
            md_image = 0xf30e,
            md_images = 0xf30f,
            md_infinite = 0xf310,
            md_information = 0xf312,
            md_information_circle = 0xf311,
            md_information_circle_outline = 0xf16f,
            md_jet = 0xf315,
            md_journal = 0xf18d,
            md_key = 0xf316,
            md_keypad = 0xf317,
            md_laptop = 0xf318,
            md_leaf = 0xf319,
            md_link = 0xf22e,
            md_list = 0xf31b,
            md_list_box = 0xf31a,
            md_locate = 0xf31c,
            md_lock = 0xf31d,
            md_log_in = 0xf31e,
            md_log_out = 0xf31f,
            md_magnet = 0xf320,
            md_mail = 0xf322,
            md_mail_open = 0xf321,
            md_mail_unread = 0xf172,
            md_male = 0xf323,
            md_man = 0xf324,
            md_map = 0xf325,
            md_medal = 0xf326,
            md_medical = 0xf327,
            md_medkit = 0xf328,
            md_megaphone = 0xf329,
            md_menu = 0xf32a,
            md_mic = 0xf32c,
            md_mic_off = 0xf32b,
            md_microphone = 0xf32d,
            md_moon = 0xf32e,
            md_more = 0xf1c9,
            md_move = 0xf331,
            md_musical_note = 0xf332,
            md_musical_notes = 0xf333,
            md_navigate = 0xf334,
            md_notifications = 0xf338,
            md_notifications_off = 0xf336,
            md_notifications_outline = 0xf337,
            md_nuclear = 0xf339,
            md_nutrition = 0xf33a,
            md_open = 0xf33b,
            md_options = 0xf33c,
            md_outlet = 0xf33d,
            md_paper = 0xf33f,
            md_paper_plane = 0xf33e,
            md_partly_sunny = 0xf340,
            md_pause = 0xf341,
            md_paw = 0xf342,
            md_people = 0xf343,
            md_person = 0xf345,
            md_person_add = 0xf344,
            md_phone_landscape = 0xf346,
            md_phone_portrait = 0xf347,
            md_photos = 0xf348,
            md_pie = 0xf349,
            md_pin = 0xf34a,
            md_pint = 0xf34b,
            md_pizza = 0xf354,
            md_planet = 0xf356,
            md_play = 0xf357,
            md_play_circle = 0xf174,
            md_podium = 0xf358,
            md_power = 0xf359,
            md_pricetag = 0xf35a,
            md_pricetags = 0xf35b,
            md_print = 0xf35c,
            md_pulse = 0xf35d,
            md_qr_scanner = 0xf35e,
            md_quote = 0xf35f,
            md_radio = 0xf362,
            md_radio_button_off = 0xf360,
            md_radio_button_on = 0xf361,
            md_rainy = 0xf363,
            md_recording = 0xf364,
            md_redo = 0xf365,
            md_refresh = 0xf366,
            md_refresh_circle = 0xf228,
            md_remove = 0xf368,
            md_remove_circle = 0xf367,
            md_remove_circle_outline = 0xf176,
            md_reorder = 0xf369,
            md_repeat = 0xf36a,
            md_resize = 0xf36b,
            md_restaurant = 0xf36c,
            md_return_left = 0xf36d,
            md_return_right = 0xf36e,
            md_reverse_camera = 0xf36f,
            md_rewind = 0xf370,
            md_ribbon = 0xf371,
            md_rocket = 0xf179,
            md_rose = 0xf372,
            md_sad = 0xf373,
            md_save = 0xf1a9,
            md_school = 0xf374,
            md_search = 0xf375,
            md_send = 0xf376,
            md_settings = 0xf377,
            md_share = 0xf379,
            md_share_alt = 0xf378,
            md_shirt = 0xf37a,
            md_shuffle = 0xf37b,
            md_skip_backward = 0xf37c,
            md_skip_forward = 0xf37d,
            md_snow = 0xf37e,
            md_speedometer = 0xf37f,
            md_square = 0xf381,
            md_square_outline = 0xf380,
            md_star = 0xf384,
            md_star_half = 0xf382,
            md_star_outline = 0xf383,
            md_stats = 0xf385,
            md_stopwatch = 0xf386,
            md_subway = 0xf387,
            md_sunny = 0xf388,
            md_swap = 0xf389,
            md_switch = 0xf38a,
            md_sync = 0xf38b,
            md_tablet_landscape = 0xf38c,
            md_tablet_portrait = 0xf38d,
            md_tennisball = 0xf38e,
            md_text = 0xf38f,
            md_thermometer = 0xf390,
            md_thumbs_down = 0xf391,
            md_thumbs_up = 0xf392,
            md_thunderstorm = 0xf393,
            md_time = 0xf394,
            md_timer = 0xf395,
            md_today = 0xf17d,
            md_train = 0xf396,
            md_transgender = 0xf397,
            md_trash = 0xf398,
            md_trending_down = 0xf399,
            md_trending_up = 0xf39a,
            md_trophy = 0xf39b,
            md_tv = 0xf17f,
            md_umbrella = 0xf39c,
            md_undo = 0xf39d,
            md_unlock = 0xf39e,
            md_videocam = 0xf39f,
            md_volume_high = 0xf123,
            md_volume_low = 0xf131,
            md_volume_mute = 0xf3a1,
            md_volume_off = 0xf3a2,
            md_walk = 0xf3a4,
            md_wallet = 0xf18f,
            md_warning = 0xf3a5,
            md_watch = 0xf3a6,
            md_water = 0xf3a7,
            md_wifi = 0xf3a8,
            md_wine = 0xf3a9,
            md_woman = 0xf3aa,
        }
    }
}