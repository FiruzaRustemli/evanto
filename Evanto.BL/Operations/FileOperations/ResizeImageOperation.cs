using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;
using System.IO;
using System.Web.Hosting;
using System.Web;
using System.Runtime;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.FileOperations
{
    public class ResizeImageOperation : Operation<ResizeImageInput, ResizeImageOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods

        public override void DoExecute()
        {
            ResizeImageOutput output = new ResizeImageOutput();
            if (Convert.FromBase64String(Parameters.Container).Length<1048576)
            {
                byte[] bytes = Convert.FromBase64String(Parameters.Container);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    Bitmap thumb = new Bitmap(Parameters.Width, Parameters.Height);
                    using (var bmp = Image.FromStream(ms))
                    {
                        using (Graphics g = Graphics.FromImage(thumb))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.DrawImage(bmp, 0, 0, Parameters.Width, Parameters.Height);
                        }
                    }
                    // a picturebox to show/test the result
                    using (MemoryStream ms1 = new MemoryStream())
                    {
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        Encoder myEncoder = Encoder.Quality;
                        EncoderParameters myEncoderParameters = new EncoderParameters(1);

                        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        //First Convert Image to byte[]
                        thumb.Save(ms1, jpgEncoder, myEncoderParameters);
                        byte[] imageBytes1 = ms1.ToArray();

                        //Then Convert byte[] to Base64 String
                        output.Container = Convert.ToBase64String(imageBytes1);
                    }
                }
            }
            else
            {
                output.Container = Parameters.Container;
                Result.ErrorList.Add(new Error
                {
                    Type = OperationResultCode.Exception,
                    Text = "File size is greater than 2 mb",
                    Code = "400"
                });
            }
            Result.Output = output;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        #endregion
    }
}
