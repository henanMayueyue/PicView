﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static PicView.Copy_Paste;
using static PicView.DeleteFiles;
using static PicView.Fields;
using static PicView.Helper;
using static PicView.Open_Save;
using static PicView.RecentFiles;
using static PicView.SvgIcons;
using static PicView.Wallpaper;

namespace PicView
{
    internal static class ContextMenus
    {
        internal static void AddContextMenus()
        {
            // Add main contextmenu
            cm = new ContextMenu();
            var scbf = (SolidColorBrush)Application.Current.Resources["MainColorFadedBrush"];


            ///////////////////////////
            ///////////////////////////
            ///     Open           \\\\
            ///////////////////////////
            ///////////////////////////
            var opencm = new MenuItem
            {
                Header = "Open",
                InputGestureText = "Ctrl + O"
            };
            var opencmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconFile),
                Stretch = Stretch.Fill
            };
            opencmIcon.Width = opencmIcon.Height = 12;
            opencmIcon.Fill = scbf;
            opencm.Icon = opencmIcon;
            opencm.Click += (s, x) => Open();
            cm.Items.Add(opencm);


            ///////////////////////////
            ///////////////////////////
            ///     Save           \\\\
            ///////////////////////////
            ///////////////////////////
            var savecm = new MenuItem()
            {
                Header = "Save",
                InputGestureText = "Ctrl + S"
            };
            var savecmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconSave),
                Stretch = Stretch.Fill
            };
            savecmIcon.Width = savecmIcon.Height = 12;
            savecmIcon.Fill = scbf;
            savecm.Icon = savecmIcon;
            savecm.Click += (s, x) => SaveFiles();
            cm.Items.Add(savecm);



            ///////////////////////////
            ///////////////////////////
            ///     Print          \\\\
            ///////////////////////////
            ///////////////////////////
            var printcm = new MenuItem
            {
                Header = "Print",
                InputGestureText = "Ctrl + P"
            };
            var printcmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconPrint),
                Stretch = Stretch.Fill
            };
            printcmIcon.Width = printcmIcon.Height = 12;
            printcmIcon.Fill = scbf;
            printcm.Icon = printcmIcon;
            printcm.Click += (s, x) => Print(Pics[FolderIndex]);
            cm.Items.Add(printcm);


            ///////////////////////////
            ///////////////////////////
            ///     Recent Files   \\\\
            ///////////////////////////
            ///////////////////////////
            cm.Items.Add(new Separator());
            var recentcm = new MenuItem
            {
                Header = "Recent files"
            };
            var recentcmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconPaper),
                Stretch = Stretch.Fill
            };
            recentcmIcon.Width = recentcmIcon.Height = 12;
            recentcmIcon.Fill = scbf;
            recentcm.Icon = recentcmIcon;
            cm.Items.Add(recentcm);

            ///////////////////////////
            ///////////////////////////
            ///     Sort Files     \\\\
            ///////////////////////////
            ///////////////////////////
            var sortcm = new MenuItem
            {
                Header = "Sort files by"
            };
            var sortcmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconSort),
                Stretch = Stretch.Fill
            };
            sortcmIcon.Width = sortcmIcon.Height = 12;
            sortcmIcon.Fill = scbf;
            sortcm.Icon = sortcmIcon;

            ///////////////////////////
            ///   File Name        \\\\
            ///////////////////////////
            var sortcmChild0 = new MenuItem();
            var sortcmChild0Header = new RadioButton
            {
                Content = "File name",
                IsChecked = Properties.Settings.Default.SortPreference == 0
            };
            sortcmChild0Header.Click += delegate { Configs.ChangeSorting(0); cm.IsOpen = false; };
            sortcmChild0.Click += delegate { Configs.ChangeSorting(0); cm.IsOpen = false; };
            sortcmChild0.Header = sortcmChild0Header;
            sortcm.Items.Add(sortcmChild0);

            ///////////////////////////
            ///   File Size        \\\\
            ///////////////////////////
            var sortcmChild1 = new MenuItem();
            var sortcmChild1Header = new RadioButton
            {
                Content = "File Size",
                IsChecked = Properties.Settings.Default.SortPreference == 1
            };
            sortcmChild1Header.Click += delegate { Configs.ChangeSorting(1); cm.IsOpen = false; };
            sortcmChild1.Click += delegate { Configs.ChangeSorting(1); cm.IsOpen = false; };
            sortcmChild1.Header = sortcmChild1Header;
            sortcm.Items.Add(sortcmChild1);

            ///////////////////////////
            ///   Creation Time     \\\\
            ///////////////////////////
            var sortcmChild2 = new MenuItem();
            var sortcmChild2Header = new RadioButton
            {
                Content = "Creation time",
                IsChecked = Properties.Settings.Default.SortPreference == 2

            };
            sortcmChild2Header.Click += delegate { Configs.ChangeSorting(2); cm.IsOpen = false; };
            sortcmChild2.Click += delegate { Configs.ChangeSorting(2); cm.IsOpen = false; };
            sortcmChild2.Header = sortcmChild2Header;
            sortcm.Items.Add(sortcmChild2);

            ///////////////////////////
            ///   File extension   \\\\
            ///////////////////////////
            var sortcmChild3 = new MenuItem();
            var sortcmChild3Header = new RadioButton
            {
                Content = "File extension",
                IsChecked = Properties.Settings.Default.SortPreference == 3
            };
            sortcmChild3Header.Click += delegate { Configs.ChangeSorting(3); cm.IsOpen = false; };
            sortcmChild3.Click += delegate { Configs.ChangeSorting(3); cm.IsOpen = false; };
            sortcmChild3.Header = sortcmChild3Header;
            sortcm.Items.Add(sortcmChild3);

            ///////////////////////////
            ///   Last Access Time \\\\
            ///////////////////////////
            var sortcmChild4 = new MenuItem();
            var sortcmChild4Header = new RadioButton
            {
                Content = "Last access time",
                IsChecked = Properties.Settings.Default.SortPreference == 4
            };
            sortcmChild4Header.Click += delegate { Configs.ChangeSorting(4); cm.IsOpen = false; };
            sortcmChild4.Click += delegate { Configs.ChangeSorting(4); cm.IsOpen = false; };
            sortcmChild4.Header = sortcmChild4Header;
            sortcm.Items.Add(sortcmChild4);

            ///////////////////////////
            ///   Last Write Time  \\\\
            ///////////////////////////
            var sortcmChild5 = new MenuItem();
            var sortcmChild5Header = new RadioButton
            {
                Content = "Last write time",
                IsChecked = Properties.Settings.Default.SortPreference == 5
            };
            sortcmChild5Header.Click += delegate { Configs.ChangeSorting(5); cm.IsOpen = false; };
            sortcmChild5.Click += delegate { Configs.ChangeSorting(5); cm.IsOpen = false; };
            sortcmChild5.Header = sortcmChild5Header;
            sortcm.Items.Add(sortcmChild5);

            ///////////////////////////
            ///   Random        \\\\
            ///////////////////////////
            var sortcmChild6 = new MenuItem();
            var sortcmChild6Header = new RadioButton
            {
                Content = "Random",
                IsChecked = Properties.Settings.Default.SortPreference == 6
            };
            sortcmChild6Header.Click += delegate { Configs.ChangeSorting(6); cm.IsOpen = false; };
            sortcmChild6.Click += delegate { Configs.ChangeSorting(6); cm.IsOpen = false; };
            sortcmChild6.Header = sortcmChild6Header;
            sortcm.Items.Add(sortcmChild6);
            cm.Items.Add(sortcm);


            ///////////////////////////
            ///////////////////////////
            ///     Settings       \\\\
            ///////////////////////////
            ///////////////////////////
            var settingscm = new MenuItem
            {
                Header = "Setings"
            };
            var settingscmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconWrench),
                Stretch = Stretch.Fill
            };
            settingscmIcon.Width = settingscmIcon.Height = 12;
            settingscmIcon.Fill = scbf;
            settingscm.Icon = settingscmIcon;
            cm.Items.Add(settingscm);

            ///////////////////////////
            ///   Looping          \\\\
            ///////////////////////////
            var settingscmLoop = new MenuItem
            {
                InputGestureText = "L"
            };
            var settingscmLoopHeader = new CheckBox
            {
                IsChecked = Properties.Settings.Default.Looping,
                Content = "Looping",
                FontSize = 13,
                Width = double.NaN,
                Height = double.NaN
            };
            settingscmLoopHeader.Style = Application.Current.FindResource("Checkstyle") as Style;
            settingscmLoopHeader.HorizontalAlignment = HorizontalAlignment.Left;
            settingscmLoop.Header = settingscmLoopHeader;
            //var settingscmLoopIcon = new System.Windows.Shapes.Path
            //{
            //    Data = Geometry.Parse(InfiniteIconSVG),
            //    Stretch = Stretch.Fill,
            //    Width = 13,
            //    Height = 13,
            //    Fill = scbf
            //};
            //settingscmLoop.Icon = settingscmLoopIcon;
            settingscmLoop.Click += (s, x) => { Configs.SetLooping(s, x); };
            settingscmLoopHeader.Click += (s, x) => { Configs.SetLooping(s, x); };
            settingscm.Items.Add(settingscmLoop);

            ///////////////////////////
            ///   Scroll         \\\\
            ///////////////////////////
            var settingscmScroll = new MenuItem
            {
                InputGestureText = "X"
            };
            var settingscmScrollHeader = new CheckBox
            {
                IsChecked = Properties.Settings.Default.ScrollEnabled,
                Content = "Scrolling",
                FontSize = 13,
                Width = double.NaN,
                Height = double.NaN
            };
            settingscmScrollHeader.Click += Configs.SetScrolling;
            settingscmScrollHeader.Style = Application.Current.FindResource("Checkstyle") as Style;
            settingscmScrollHeader.HorizontalAlignment = HorizontalAlignment.Left;
            settingscmScroll.Header = settingscmScrollHeader;
            settingscmScroll.Click += (s, x) => { Configs.SetScrolling(s, x); settingscmScrollHeader.IsChecked = (bool)settingscmScrollHeader.IsChecked ? false : true; };
            settingscm.Items.Add(settingscmScroll);

            ///////////////////////////
            ///   Fit to window    \\\\
            ///////////////////////////
            var fitcm = new MenuItem
            {
                InputGestureText = "E"
            };
            var fitcmHeader = new CheckBox
            {
                Content = "Fit to window",
                IsChecked = Properties.Settings.Default.FitToWindow,
                FontSize = 13,
                Width = double.NaN,
                Height = double.NaN
            };
            fitcmHeader.Click += delegate { WindowLogic.FitToWindow = WindowLogic.FitToWindow ? false : true; };
            fitcmHeader.Style = Application.Current.FindResource("Checkstyle") as Style;
            fitcmHeader.HorizontalAlignment = HorizontalAlignment.Left;
            fitcm.Header = fitcmHeader;
            fitcm.Click += delegate { WindowLogic.FitToWindow = WindowLogic.FitToWindow ? false : true; };
            settingscm.Items.Add(fitcm);

            ///////////////////////////
            ///   Alt interface    \\\\
            ///////////////////////////
            var altcm = new MenuItem
            {
                InputGestureText = "Alt + Z"
            };
            var altcmHeader = new CheckBox
            {
                Content = "Show/hide interface",
                IsChecked = Properties.Settings.Default.ShowInterface,
                FontSize = 13,
                Width = double.NaN,
                Height = double.NaN
            };
            altcmHeader.Click += delegate { HideInterfaceLogic.ToggleInterface(); };
            altcmHeader.Style = Application.Current.FindResource("Checkstyle") as Style;
            altcmHeader.HorizontalAlignment = HorizontalAlignment.Left;
            altcm.Header = altcmHeader;
            altcm.Click += delegate { HideInterfaceLogic.ToggleInterface(); };
            settingscm.Items.Add(altcm);

            ///////////////////////////
            ///   Transparent bg   \\\\
            ///////////////////////////
            var transcm = new MenuItem
            {
                InputGestureText = "T"
            };
            var transcmHeader = new CheckBox
            {
                Content = "White background",
                ToolTip = "Change between white and transparent background for images",
                IsChecked = Properties.Settings.Default.BgColorWhite,
                FontSize = 13,
                Width = double.NaN,
                Height = double.NaN
            };
            transcmHeader.Click += (s, x) => { ChangeBackground(s, x); };
            transcmHeader.Style = Application.Current.FindResource("Checkstyle") as Style;
            transcmHeader.HorizontalAlignment = HorizontalAlignment.Left;
            transcm.Header = transcmHeader;
            transcm.Click += (s, x) => { ChangeBackground(s, x); };
            settingscm.Items.Add(transcm);

            cm.Items.Add(new Separator());

            ///////////////////////////
            ///////////////////////////
            ///  Set as Wallpaper  \\\\
            ///////////////////////////
            ///////////////////////////
            var wallcm = new MenuItem
            {
                Header = "Set as wallpaper"
            };
            wallcm.Click += (s, x) => SetWallpaper(Pics[FolderIndex], WallpaperStyle.Fill);
            var wallcmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconCamera),
                Stretch = Stretch.Fill
            };
            wallcmIcon.Width = wallcmIcon.Height = 12;
            wallcmIcon.Fill = scbf;
            wallcm.Icon = wallcmIcon;
            cm.Items.Add(wallcm);


            ///////////////////////////
            ///////////////////////////
            ///   Locate on disk   \\\\
            ///////////////////////////
            ///////////////////////////
            var lcdcm = new MenuItem
            {
                Header = "Locate on disk",
                InputGestureText = "F3",
                ToolTip = "Opens the current image on your drive"
            };
            var lcdcmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconSearch),
                Stretch = Stretch.Fill
            };
            lcdcmIcon.Width = lcdcmIcon.Height = 12;
            lcdcmIcon.Fill = scbf;
            lcdcm.Icon = lcdcmIcon;
            lcdcm.Click += (s, x) => Open_In_Explorer();
            cm.Items.Add(lcdcm);


            ///////////////////////////
            ///////////////////////////
            ///   File Details     \\\\
            ///////////////////////////
            ///////////////////////////
            var fildecm = new MenuItem
            {
                Header = "File Details",
                InputGestureText = "Ctrl + I"
            };
            var fildecmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconPaperDetails),
                Stretch = Stretch.Fill
            };
            fildecmIcon.Width = fildecmIcon.Height = 12;
            fildecmIcon.Fill = scbf;
            fildecm.Icon = fildecmIcon;
            fildecm.Click += (s, x) => NativeMethods.ShowFileProperties(Pics[FolderIndex]);
            cm.Items.Add(fildecm);
            cm.Items.Add(new Separator());

            ///////////////////////////
            ///////////////////////////
            ///   Copy Picture     \\\\
            ///////////////////////////
            ///////////////////////////
            var cppcm = new MenuItem
            {
                Header = "Copy picture",
                InputGestureText = "Ctrl + C"
            };
            var cppcmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconCopy),
                Stretch = Stretch.Fill
            };
            cppcmIcon.Width = cppcmIcon.Height = 12;
            cppcmIcon.Fill = scbf;
            cppcm.Icon = cppcmIcon;
            cppcm.Click += (s, x) => CopyPic();
            cm.Items.Add(cppcm);

            ///////////////////////////
            ///////////////////////////
            ///   Cut Picture      \\\\
            ///////////////////////////
            ///////////////////////////
            var cpccm = new MenuItem
            {
                Header = "Cut picture",
                InputGestureText = "Ctrl + X"
            };
            var cpccmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconScissor),
                Stretch = Stretch.Fill
            };
            cpccmIcon.Width = cpccmIcon.Height = 12;
            cpccmIcon.Fill = scbf;
            cpccm.Icon = cpccmIcon;
            cpccm.Click += (s, x) => Cut(Pics[FolderIndex]);
            cm.Items.Add(cpccm);

            ///////////////////////////
            ///////////////////////////
            ///   Paste Picture    \\\\
            ///////////////////////////
            ///////////////////////////
            var pastecm = new MenuItem
            {
                Header = "Paste picture",
                InputGestureText = "Ctrl + V"
            };
            var pastecmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconPaste),
                Stretch = Stretch.Fill,
                Width = 12,
                Height = 12,
                Fill = scbf
            };
            pastecm.Icon = pastecmIcon;
            pastecm.Click += (s, x) => Paste();
            cm.Items.Add(pastecm);

            ///////////////////////////
            ///////////////////////////
            ///   Delete Picture   \\\\
            ///////////////////////////
            ///////////////////////////
            var MovetoRecycleBin = new MenuItem
            {
                Header = "Delete picture",
                InputGestureText = "Delete"
            };
            var MovetoRecycleBinIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconRecycle),
                Stretch = Stretch.Fill,
                Width = 12,
                Height = 12,
                Fill = scbf
            };
            MovetoRecycleBin.Icon = MovetoRecycleBinIcon;
            MovetoRecycleBin.Click += (s, x) => DeleteFile(Pics[FolderIndex], true);
            cm.Items.Add(MovetoRecycleBin);


            ///////////////////////////
            ///////////////////////////
            ///   Close            \\\\
            ///////////////////////////
            ///////////////////////////
            cm.Items.Add(new Separator());
            var clcm = new MenuItem
            {
                Header = "Close",
                InputGestureText = "Esc",
                StaysOpenOnClick = false
            };
            var mclcmIcon = new System.Windows.Shapes.Path
            {
                Data = Geometry.Parse(SVGiconClose),
                Stretch = Stretch.Fill,
                Width = 12,
                Height = 12,
                Fill = scbf
            };
            clcm.Icon = mclcmIcon;
            clcm.Click += (s, x) => { cm.Visibility = Visibility.Collapsed; SystemCommands.CloseWindow(mainWindow); };
            cm.Items.Add(clcm);

            // Add to elements
            mainWindow.img.ContextMenu = mainWindow.bg.ContextMenu = mainWindow.LowerBar.ContextMenu = cm;

            // Add left and right ContextMenus
            //var cmLeft = new ContextMenu();
            //var cmRight = new ContextMenu();

            //var nextcm = new MenuItem
            //{
            //    Header = "Next picture",
            //    InputGestureText = "ᗌ or D",
            //    ToolTip = "Go to Next image",
            //    StaysOpenOnClick = true
            //};
            //nextcm.Click += (s, x) => Pic();
            //cmRight.Items.Add(nextcm);

            //var prevcm = new MenuItem
            //{
            //    Header = "Previous picture",
            //    InputGestureText = "ᗏ or A",
            //    ToolTip = "Go to previous image in folder",
            //    StaysOpenOnClick = true
            //};
            //prevcm.Click += (s, x) => Pic(false);
            //cmLeft.Items.Add(prevcm);

            //var firstcm = new MenuItem
            //{
            //    Header = "First picture",
            //    InputGestureText = "Ctrl + D or Ctrl + ᗌ",
            //    ToolTip = "Go to first image in folder"
            //};
            //firstcm.Click += (s, x) => Pic(false, true);
            //cmLeft.Items.Add(firstcm);

            //var lastcm = new MenuItem
            //{
            //    Header = "Last picture",
            //    InputGestureText = "Ctrl + A or Ctrl + ᗏ",
            //    ToolTip = "Go to last image in folder"
            //};
            //lastcm.Click += (s, x) => Pic(true, true);
            //cmRight.Items.Add(lastcm);

            //// Add to elements
            //mainWindow.RightButton.ContextMenu = cmRight;
            //mainWindow.LeftButton.ContextMenu = cmLeft;

            //clickArrowRight.ContextMenu = cmRight;
            //clickArrowLeft.ContextMenu = cmLeft;

            // Add Title contextMenu
            var cmTitle = new ContextMenu();

            var clTc = new MenuItem
            {
                Header = "Copy path to clipboard"
            };
            clTc.Click += (s, x) => CopyText();
            cmTitle.Items.Add(clTc);

            mainWindow.Bar.ContextMenu = cmTitle;

            switch (Properties.Settings.Default.SortPreference)
            {
                case 0:
                    sortcmChild0.IsChecked = true;
                    break;

                case 1:
                    sortcmChild1.IsChecked = true;
                    break;

                case 2:
                    sortcmChild2.IsChecked = true;
                    break;

                case 3:
                    sortcmChild3.IsChecked = true;
                    break;

                case 4:
                    sortcmChild4.IsChecked = true;
                    break;

                case 5:
                    sortcmChild5.IsChecked = true;
                    break;

                case 6:
                    sortcmChild6.IsChecked = true;
                    break;

                default:
                    sortcmChild0.IsChecked = true;
                    break;
            }

            cm.Opened += (tt, yy) => Recentcm_MouseEnter(recentcm);
        }
    }
}
