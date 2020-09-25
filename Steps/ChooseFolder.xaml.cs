using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Financeiro_Installer.Steps {

    public partial class ChooseFolder : UserControl {

        public ChooseFolder() {
            InitializeComponent();
            string default_path = @"C:\Program Files";
            if (Directory.Exists(default_path)) {
                PastaTB.Text = default_path;
            }
        }

        bool Completed { get; set; } = false;

        private void ProcurarB_Click(object sender, RoutedEventArgs e) {
            if (WindowsSO.ChooseFolder(out string path)) {
                PastaTB.Text = path;
            }
        }

        private void PastaTB_TextChanged(object sender, TextChangedEventArgs e) {
            IniciarB.IsEnabled = Directory.Exists(PastaTB.Text);
        }

        private async void IniciarB_Click(object sender, RoutedEventArgs e) {
            try {
                LogSP.Children.Clear();
                if (Completed) {
                    Environment.Exit(Environment.ExitCode);
                } else {
                    var choosen_directory = PastaTB.Text + @"\Clinica Financeiro";
                    if (Directory.Exists(choosen_directory)) Directory.Delete(choosen_directory, true);
                    Log($"Criando pasta \"{choosen_directory}\"");
                    Directory.CreateDirectory(choosen_directory);
                    var fi = await CreateZipFile(choosen_directory);
                    ZipFile.ExtractToDirectory(fi.FullName, choosen_directory);
                    var origin = choosen_directory + @"\Release";
                    await WindowsSO.Copy(origin, choosen_directory, (old_entity, new_entity) => {
                        Log($"Copiando \"{new_entity}\"");
                        return true;
                    });
                    Log($"Deletando pasta \"{origin}\"");
                    Directory.Delete(origin, true);
                    if (CreateShortcutCB.IsChecked ?? false) {
                        Log("Criando atalho.");
                        WindowsSO.CreateShortcut(choosen_directory + @"\Financeiro.exe");
                    }
                    Log("Concluído.", Brushes.Green);
                    IniciarB.Content = $"Fechar";
                    Completed = true;
                }
            } catch (Exception ex) {
                Log(ex.Message, Brushes.Red);
                Log(ex.StackTrace, Brushes.Red);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choosen_directory"></param>
        /// <returns>The file info object of the zip file.</returns>
        async Task<FileInfo> CreateZipFile(string choosen_directory) {
            byte[] bytes;
            if (Environment.Is64BitOperatingSystem) {
                bytes = Properties.Resources.Release_x64;
            } else {
                bytes = Properties.Resources.Release_x86;
            }
            FileInfo fi = new FileInfo(choosen_directory + @"\Release.zip");
            if (File.Exists(fi.FullName)) File.Delete(fi.FullName);
            using var sw = new FileStream(fi.FullName, FileMode.Create);
            await sw.WriteAsync(bytes, 0, bytes.Length);
            return fi;
        }

        void Log(string message, Brush foreground = null) {
            var tbl = new TextBlock() {
                Text = message,
                Foreground = foreground ?? Brushes.Black
            };
            LogSP.Children.Add(tbl);
            LogSV.ScrollToBottom();
        }

    }
}
