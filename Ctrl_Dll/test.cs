using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Imaging;
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;

namespace Ctrl_Dll
{
    internal class test:window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 画像ファイルの読み込みと表示
            Stream input_stream = new FileStream("test.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            var source = new WriteableBitmap(System.Windows.Media.Imaging.BitmapFrame.Create(input_stream));
            imgSrc.Source = source;
            input_stream.Close();

            // 画像データをメモリストリームへ書き出し
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(source));
            MemoryStream temp_stream = new MemoryStream();
            encoder.Save(temp_stream);

            // メモリストリームを変換
            var converted_stream = WindowsRuntimeStreamExtensions.AsRandomAccessStream(temp_stream);

            // メモリストリームからOCR用画像データの生成
            var decorder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(converted_stream);
            SoftwareBitmap bitmap = await decorder.GetSoftwareBitmapAsync();
            converted_stream.Dispose();
            temp_stream.Close();

            // OCRの実行
            OcrEngine engine = OcrEngine.TryCreateFromLanguage(new Windows.Globalization.Language("ja-JP"));
            var result = await engine.RecognizeAsync(bitmap);

            txtResult.Text = result.Text;
        }
    }
}
