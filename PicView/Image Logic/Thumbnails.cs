﻿using ImageMagick;
using PicView.PreLoading;
using PicView.UserControls;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Imaging;
using static PicView.Fields;

namespace PicView
{
    internal static class Thumbnails
    {
        /// <summary>
        /// Load thumbnail at current index
        /// or full image if preloaded.
        /// </summary>
        /// <returns></returns>
        internal static BitmapSource GetThumb()
        {
            var pic = Preloader.Load(Pics[FolderIndex]);

            if (pic == null)
            {
                if (picGallery != null)
                {
                    if (FolderIndex < picGallery.Container.Children.Count && picGallery.Container.Children.Count == Pics.Count)
                    {
                        var y = picGallery.Container.Children[FolderIndex] as PicGalleryItem;
                        pic = (BitmapSource)y.img.Source;
                    }
                    else
                    {
                        pic = GetWindowsThumbnail(Pics[FolderIndex]);

                        if (pic == null)
                        {
                            pic = GetBitmapSourceThumb(Pics[FolderIndex]);
                        }
                    }
                }
                else
                {
                    pic = GetWindowsThumbnail(Pics[FolderIndex]);

                    if (pic == null)
                    {
                        pic = GetBitmapSourceThumb(Pics[FolderIndex]);
                    }
                }
            }

            return pic;
        }

        internal static BitmapSource GetBitmapSourceThumb(string path)
        {
            var supported = SupportedFiles.IsSupportedFile(path);

            if (!supported.HasValue)
            {
                return null;
            }

            if (supported.Value)
            {
                return GetWindowsThumbnail(path);
            }
            else if (!supported.Value)
            {
                return GetMagickImage(path, 60, 55);
            }

            return null;
        }

        /// <summary>
        /// Returns BitmapSource at specified quality and pixel size
        /// </summary>
        /// <param name="file"></param>
        /// <param name="quality"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        internal static BitmapSource GetMagickImage(string file, byte quality, short size)
        {
            BitmapSource pic;

            using (MagickImage magick = new MagickImage())
            {
                magick.Quality = quality;
                magick.ColorSpace = ColorSpace.Transparent;
                try
                {
                    magick.Read(file);
                    magick.AdaptiveResize(size, size);

                }
#if DEBUG
                catch (MagickException e)
                {

                    Trace.WriteLine("GetMagickImage returned " + file + " null, \n" + e.Message);
                    return null;
                }
#else
                catch (MagickException) { return null; }
#endif
                pic = magick.ToBitmapSource();
                pic.Freeze();
                return pic;
            }
        }

        /// <summary>
        /// Returns a Windows Thumbnail
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns></returns>
        internal static BitmapSource GetWindowsThumbnail(string path, bool extralarge = false)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            if (extralarge)
            {
                return Microsoft.WindowsAPICodePack.Shell.ShellFile.FromFilePath(path).Thumbnail.ExtraLargeBitmapSource;
            }

            return Microsoft.WindowsAPICodePack.Shell.ShellFile.FromFilePath(path).Thumbnail.BitmapSource;
        }
    }
}
