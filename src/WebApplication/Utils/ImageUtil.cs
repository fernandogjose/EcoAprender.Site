using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication.Utils
{
    public class ImageUtil
    {
        public void Validar(HttpPostedFileBase httpPostedFileBase)
        {
            if (httpPostedFileBase == null || string.IsNullOrEmpty(httpPostedFileBase.FileName))
                return;

            if (httpPostedFileBase.ContentLength > 12048576)
            {
                throw new Exception("Não é permitido fotos com mais de 12mb");
            }

            var extension = Path.GetExtension(httpPostedFileBase.FileName);
            if (extension != null)
            {
                var fileExt = extension.Substring(1);
            }
        }

        public void UploadFoto(HttpPostedFileBase httpPostedFileBase, string pathDestino)
        {
            if (httpPostedFileBase == null || httpPostedFileBase.ContentLength <= 0) return;

            //--- Cria o diretório para gravar as fotos caso não ainda não exista
            var directoryInfo = new DirectoryInfo(pathDestino);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            //--- Faz o upload da foto
            var fileInfo = new FileInfo(httpPostedFileBase.FileName);
            pathDestino = string.Format(@"{0}\{1}", pathDestino, fileInfo.Name.Replace(" ", "").Trim());

            ComprimirImagem(pathDestino, httpPostedFileBase);
        }

        public void ComprimirImagem(string filePath, HttpPostedFileBase file)
        {
            Bitmap imagemAux;
            ImageCodecInfo codec;
            EncoderParameters imgParams;

            using (var img = Image.FromStream(file.InputStream))
            {
                codec = ImageCodecInfo.GetImageEncoders().First(enc => enc.FormatID == ImageFormat.Jpeg.Guid);
                imgParams = new EncoderParameters(1);
                imgParams.Param = new[] { new EncoderParameter(Encoder.Quality, 50L) };
                imagemAux = new Bitmap(img);
                img.Dispose();
            }

            imagemAux = new Bitmap(ResizeImage(imagemAux));
            imagemAux.Save(filePath, codec, imgParams);
            imagemAux.Dispose();
            imagemAux = null;
        }

        public Image ResizeImage(Bitmap fullsizeImage)
        {
            var originalWidth = fullsizeImage.Width;
            var originalHeight = fullsizeImage.Height;
            const float maxWidth = 800;
            const float maxHeight = 600;
            var ratioX = maxWidth / originalWidth;
            var ratioY = maxHeight / originalHeight;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(originalWidth * ratio);
            var newHeight = (int)(originalHeight * ratio);

            fullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            fullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

            var newImage = fullsizeImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);

            var myEncoder = Encoder.Quality;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            fullsizeImage.Dispose();
            fullsizeImage = null;

            return newImage;
        }

        public void ExcluirDiretorioOuFotoAtividade(string arquivo, bool isFile)
        {
            if (isFile)
            {
                var fileInfo = new FileInfo(arquivo);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
            else
            {
                var directory = new DirectoryInfo(arquivo);
                if (directory.Exists)
                {
                    directory.Delete(true);
                }
            }
        }

        public void RenameFolder(string de, string para)
        {
            var directoryDe = new DirectoryInfo(de);
            var directoryPara = new DirectoryInfo(para);

            if (!directoryDe.Exists)
                return;

            directoryDe.MoveTo(para);
        }

        public List<string> ListFotoAtividade(string path, int id)
        {
            var fotos = new List<string>();

            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
                return fotos;

            foreach (var file in directory.GetFiles())
            {
                fotos.Add(file.Name);
            }

            return fotos;
        }
    }
}