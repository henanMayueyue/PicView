﻿using PicView.UserControls;
using PicView.UserControls.Menus;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PicView
{
    internal static class Fields
    {
        internal const string AppName = "PicView";
        internal const string Loading = "Loading...";
        internal const string TxtCopy = "Filename added to clipboard";
        internal const string FileCopy = "File added to clipboard";
        internal const string ImageCopy = "Image added to clipboard";
        internal const string ImageCut = "Image added to move clipboard";
        internal const string ExpFind = "Locating in file explorer";
        internal const string NoImage = "No image loaded";
        internal const string BadImage = "Unable to render image";

        internal const string SupportedFilesFilter =
        " *.jpg *.jpeg *.jpe *.png *.bmp *.tif *.tiff *.gif *.ico *.wdp *.svg *.psd *.psb *.orf *.cr2 *.crw *.dng *.raf *.raw *.mrw *.nef *.x3f *.arw *.webp *"
        + ".aai *.ai *.art *.bgra *.bgro *.canvas *.cin *.cmyk *.cmyka *.cur *.cut *.dcm *.dcr *.dcx *.dds *.dfont *.dlib *.dpx *.dxt1 *.dxt5 *.emf *.epi *.eps *.ept"
        + " *.ept2 *.ept3 *.exr *.fax *.fits *.flif *.g3 *.g4 *.gif87 *.gradient *.gray *.group4 *.hald *.hdr *.hrz *.icb *.icon *.ipl *.jc2 *.j2k *.jng *.jnx"
        + " *.jpm *.jps *.jpt *.kdc *.label *.map *.nrw *.otb *.otf *.pbm *.pcd *.pcds *.pcl *.pct *.pcx *.pfa *.pfb *.pfm *.picon *.pict *.pix *.pjpeg *.png00"
        + " *.png24 *.png32 *.png48 *.png64 *.png8 *.pnm *.ppm *.ps *.radialgradient *.ras *.rgb *.rgba *.rgbo *.rla *.rle *.scr *.screenshot *.sgi *.srf *.sun"
        + " *.svgz *.tiff64 *.ttf *.vda *.vicar *.vid *.viff *.vst *.vmf *.wpg *.xbm *.xcf *.yuv";


        /// <summary>
        ///  Files filterering string used for file/save dialog
        ///  TODO update for and check file support
        /// </summary>
        internal const string FilterFiles =
            "All Supported files|*.bmp;*.jpg;*.png;*.tif;*.gif;*.ico;*.jpeg;*.wdp;*.psd;*.psb;*.cbr;*.cb7;*.cbt;"
            + "*.cbz;*.xz;*.orf;*.cr2;*.crw;*.dng;*.raf;*.ppm;*.raw;*.mrw;*.nef;*.pef;*.3xf;*.arw;*.webp;"
            + "*.zip;*.7zip;*.7z;*.rar;*.bzip2;*.tar;*.wim;*.iso;*.cab"
            ////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            + "|Pictures|*.bmp;*.jpg;*.png;.tif;*.gif;*.ico;*.jpeg*.wdp*"                                   // Common pics
            + "|jpg| *.jpg;*.jpeg*"                                                                         // JPG
            + "|bmp|*.bmp;"                                                                                 // BMP
            + "|PNG|*.png;"                                                                                 // PNG
            + "|gif|*.gif;"                                                                                 // GIF
            + "|ico|*.ico;"                                                                                 // ICO
            + "|wdp|*.wdp;"                                                                                 // WDP
            + "|svg|*.svg;"                                                                                 // SVG
            + "|tif|*.tif;"                                                                                 // Tif
            + "|Photoshop|*.psd;*.psb"                                                                      // PSD
            + "|Archives|*.zip;*.7zip;*.7z;*.rar;*.bzip2;*.tar;*.wim;*.iso;*.cab"                           // Archives
            + "|Comics|*.cbr;*.cb7;*.cbt;*.cbz;*.xz"                                                        // Comics
            + "|Camera files|*.orf;*.cr2;*.crw;*.dng;*.raf;*.ppm;*.raw;*.mrw;*.nef;*.pef;*.3xf;*.arw";      // Camera files

        internal const int picGalleryItem_Size = 230;
        internal const int picGalleryItem_Size_s = 200;

        /// <summary>
        /// The Main Window?
        /// </summary>
        internal static MainWindow mainWindow = ((MainWindow)Application.Current.MainWindow);

        ///// <summary>
        ///// File path of current image
        ///// </summary>
        //internal static string Pics[FolderIndex] { get; set; }

        /// <summary>
        /// Backup of Previous file, if changed folder etc.
        /// </summary>
        internal static string xPicPath;

        /// <summary>
        /// File path for the extracted folder
        /// </summary>
        internal static string TempZipPath { get; set; }

        /// <summary>
        /// File path for the extracted zip file
        /// </summary>
        internal static string TempZipFile { get; set; }

        internal static bool LeftbuttonClicked;
        internal static bool RightbuttonClicked;
        internal static bool imageSettingsMenuOpen;
        internal static bool fileMenuOpen;
        internal static bool quickSettingsMenuOpen;
        internal static bool functionsMenuOpen;
        internal static bool FastPicRunning;
        internal static bool isZoomed;
        internal static bool Flipped;
        internal static bool canNavigate;
        internal static bool isDraggedOver;
        internal static bool freshStartup;
        internal static bool autoScrolling;
        internal static bool clickArrowRightClicked;
        internal static bool clickArrowLeftClicked;
        internal static bool SlideshowActive;
        internal static bool reverse;
        internal static bool dialogOpen;

        /// <summary>
        /// Used to prevent overlapping in PicGallery 2
        /// and as a comfortable space for standard viewing
        /// </summary>
        internal const int ComfySpace = 520;

        /// <summary>
        /// Backup of Width data
        /// </summary>
        internal static double xWidth;

        /// <summary>
        /// Backup of Height data
        /// </summary>
        internal static double xHeight;

        /// <summary>
        /// Counter used to get/set current index
        /// </summary>
        internal static int FolderIndex { get; set; }

        ///// <summary>
        ///// Backup of FolderIndex
        ///// </summary>
        //internal static int xFolderIndex;

        /// <summary>
        /// Counter used to check if preloading is neccesary.
        /// </summary>
        internal static int PreloadCount { get; set; }

        /// <summary>
        /// Used to get and set Aspect Ratio
        /// </summary>
        internal static double AspectRatio { get; set; }

        /// <summary>
        /// Used to get and set image rotation by degrees
        /// </summary>
        internal static int Rotateint { get; set; }

        /// <summary>
        /// Used to get and set monitor size
        /// </summary>
        internal static MonitorSize MonitorInfo { get; set; }

        // UserControls
        internal static ImageSettings imageSettingsMenu;
        internal static FileMenu fileMenu;
        internal static QuickSettingsMenu quickSettingsMenu;
        internal static FunctionsMenu functionsMenu;
        internal static AjaxLoading ajaxLoading;
        internal static SexyToolTip sexyToolTip;
        internal static AutoScrollSign autoScrollSign;
        internal static ClickArrow clickArrowLeft;
        internal static ClickArrow clickArrowRight;
        internal static X2 x2;
        internal static Minus minus;
        internal static PicGallery picGallery;

        internal static Point origin;
        internal static Point start;

        /// <summary>
        /// Starting point of AutoScroll
        /// </summary>
        internal static Point? autoScrollOrigin;
        /// <summary>
        /// Current point of AutoScroll
        /// </summary>
        internal static Point autoScrollPos;

        internal static ScaleTransform st;
        internal static TranslateTransform tt;

        /// <summary>
        /// List of file paths to supported files
        /// </summary>
        internal static List<string> Pics { get; set; }


        //internal static List<ImageSource> Images { get; set; }
        /// <summary>
        /// Timer used to continously scroll with AutoScroll
        /// </summary>
        internal static Timer autoScrollTimer;

        /// <summary>
        /// Timer used to hide interface and/or scrollbar
        /// </summary>
        internal static Timer activityTimer;

        /// <summary>
        /// Timer used for FastPic()
        /// </summary>
        //internal static Timer fastPicTimer;

        /// <summary>
        /// Timer used for hide/show cursor.
        /// </summary>
        //internal static Timer HideCursorTimer;

        /// <summary>
        /// Timer used to check if mouse is idle.
        /// </summary>
        //internal static Timer MouseIdleTimer;

        /// <summary>
        /// Timer used for slideshow
        /// </summary>
        internal static Timer Slidetimer;

        /// <summary>
        /// Backup of image
        /// </summary>
        internal static ImageSource prevPicResource;

        /// <summary>
        /// Primary ContextMenu
        /// </summary>
        internal static ContextMenu cm;

        /// <summary>
        /// Helper for user color settings
        /// </summary>
        internal static Color backgroundBorderColor;
        /// <summary>
        /// Helper for user color settings
        /// </summary>
        internal static Color mainColor;

    }
}
