// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="urb31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   Defines the MainForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DllChecker
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Windows.Forms;

    using DiffPlex;
    using DiffPlex.DiffBuilder;
    using DiffPlex.DiffBuilder.Model;

    using ICSharpCode.Decompiler.CSharp;
    using ICSharpCode.Decompiler.TypeSystem;
    using Mono.Cecil;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly SynchronizationContext originalContext;
        private string SrcDirectory = @"Y:\";
        private string SnapshotDirectory = @"D:\DLLSNAPSHOT\";
        private string ReleaseDirectory = @"D:\DLLRELEASE\";
        private string DebugDirectory = @"D:\DLLDEBUG\";
        private string MsbuildPath = @"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe";
        private string PrjFile = @"C:\InvestorFullCompilation\InvestorFullCompilation\InvestorFullCompilation.sln";
        private string CommandLine = @"/t:Rebuild /p:Configuration=Release";   // /p:RunCodeAnalysis=true

        /// <summary>
        /// The src checksum dictionary.
        /// </summary>
        private readonly Dictionary<string, string> releaseChecksumDictionary = new Dictionary<string, string>();

        /// <summary>
        /// The src checksum dictionary.
        /// </summary>
        private readonly Dictionary<string, string> debugChecksumDictionary = new Dictionary<string, string>();

        /// <summary>
        /// The dst checksum dictionary.
        /// </summary>
        private readonly Dictionary<string, string> snapshotChecksumDictionary = new Dictionary<string, string>();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class. 
        /// The extension pattern.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            this.originalContext = SynchronizationContext.Current;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            this.InfoListBox.Items.Clear();
            var logFileName = Path.Combine(this.SnapshotDirectory, "dllcheck.log");
            if (File.Exists(logFileName))
            {
                var lines = File.ReadAllLines(logFileName).ToList();
                foreach (var line in lines)
                {
                    this.InfoListBox.Items.Add(line);
                }
            }

            this.SrcDirectoryTextBox.Text = this.SrcDirectory;
            this.SnapshotDirectoryTextBox.Text = this.SnapshotDirectory;
            this.ReleaseDirectoryTextBox.Text = this.ReleaseDirectory;
            this.DebugDirectoryTextBox.Text = this.DebugDirectory;
            this.MsbuildPathTextBox.Text = this.MsbuildPath;
            this.PrjFileTextBox.Text = this.PrjFile;
            this.CommandLineTextBox.Text = this.CommandLine;
        }

        private async void RebuildButtonClick(object sender, EventArgs e)
        {
            var msbuild = new MsBuild();
            var msbuildPath = this.MsbuildPathTextBox.Text;
            var prjFile = this.PrjFileTextBox.Text;
            var commandLine = this.CommandLineTextBox.Text;

            this.InfoListBox.Items.Clear();
            var result = await msbuild.Execute(msbuildPath, prjFile, commandLine, this.OutMessage);
            this.InfoListBox.Items.Add(result.ToString());
            if (this.InfoListBox.Items.Cast<string>().Any(item => item.Contains("Сборка успешно завершена.")))
            {
                this.InfoListBox.Items.Add("MsBuild Ok!");
                MessageBox.Show(@"MsBuild Ok!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.InfoListBox.Items.Add("MsBuild Error!");
                MessageBox.Show(@"MsBuild Error!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OutMessage(string message)
        {
            this.originalContext.Post(c => { this.InfoListBox.Items.Add(c.ToString()); }, message);
        }

        /// <summary>
        /// The check button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CheckButtonClick(object sender, EventArgs e)
        {
            this.InfoListBox.Items.Clear();
            const string ExtensionPattern = @"*.dll";
            var appUpdateFiles = Directory.GetFiles($"{this.SrcDirectory}", ExtensionPattern, SearchOption.TopDirectoryOnly);
            this.MainProgressBar.Value = 0;
            this.MainProgressBar.Maximum = appUpdateFiles.Length;
            this.MainStatusLabel.Text = $"Копирование из {this.SrcDirectory}*.dll в {this.SnapshotDirectory}*.dll";
            this.InfoListBox.Items.Add(this.MainStatusLabel.Text);
            this.InfoListBox.Items.Add($"Сравнение  {this.SnapshotDirectory}*.dll  с {this.ReleaseDirectory}*.dll ({this.DebugDirectory}*.dll)");

            if (!Directory.Exists(this.SnapshotDirectory))
            {
                Directory.CreateDirectory(this.SnapshotDirectory);
            }

            foreach (var appUpdateFile in appUpdateFiles)
            {
                var file = Path.GetFileName(appUpdateFile);
                if (file == null)
                {
                    this.InfoListBox.Items.Add("\t\tError! No file name " + appUpdateFile);
                    continue;
                }

                var probeFile = Path.Combine(this.SnapshotDirectory, file);
                File.Copy(appUpdateFile, probeFile, true);
                this.MainProgressBar.Value++;
                this.MainStatusStrip.Refresh();
            } 

            try
            {
                this.releaseChecksumDictionary.Clear();
                var releaseFiles = Directory.GetFiles(this.ReleaseDirectory, ExtensionPattern, SearchOption.AllDirectories);
                foreach (var filePath in releaseFiles)
                {
                    var checksum = this.ComputeMD5Checksum(filePath);
                    var file = Path.GetFileName(filePath);
                    if (file == null)
                    {
                        this.InfoListBox.Items.Add("\t\tError! No file name " + filePath);
                        continue;
                    }

                    try
                    {
                        this.releaseChecksumDictionary.Add(file, checksum);
                    }
                    catch (Exception ex)
                    {
                        this.InfoListBox.Items.Add("Error! " + filePath + " " + ex.Message);
                    }
                }

                this.debugChecksumDictionary.Clear();
                var debugFiles = Directory.GetFiles(this.DebugDirectory, ExtensionPattern, SearchOption.AllDirectories);
                foreach (var filePath in debugFiles)
                {
                    var checksum = this.ComputeMD5Checksum(filePath);
                    var file = Path.GetFileName(filePath);
                    if (file == null)
                    {
                        this.InfoListBox.Items.Add("\t\tError! No file name " + filePath);
                        continue;
                    }

                    try
                    {
                        this.debugChecksumDictionary.Add(file, checksum);
                    }
                    catch (Exception ex)
                    {
                        this.InfoListBox.Items.Add("Error! " + filePath + " " + ex.Message);
                    }
                }

                this.snapshotChecksumDictionary.Clear();
                var probeFiles = Directory.GetFiles(this.SnapshotDirectory, ExtensionPattern, SearchOption.AllDirectories);
                foreach (var filePath in probeFiles)
                {
                    var checksum = this.ComputeMD5Checksum(filePath);
                    var file = Path.GetFileName(filePath);
                    if (file == null)
                    {
                        this.InfoListBox.Items.Add("\t\tError! No file name " + filePath);
                        continue;
                    }

                    try
                    {
                        this.snapshotChecksumDictionary.Add(file, checksum);
                    }
                    catch (Exception ex)
                    {
                        this.InfoListBox.Items.Add("Error! " + filePath + " " + ex.Message);
                    }
                }

                var count = 0;

                this.MainProgressBar.Value = 0;
                this.MainProgressBar.Maximum = this.releaseChecksumDictionary.Count;
                this.MainStatusLabel.Text = @"Проверка...";
                foreach (var dict in this.releaseChecksumDictionary)
                {
                    var file = dict.Key;
                    if (file.Contains("DocumentFormat.OpenXml") || file.Contains("UnitTest") || file.Contains("FastReport") || file.Contains("PdfSharp"))
                    {
                        this.InfoListBox.Items.Add($"\t{file} \t\tSkiped!");
                        continue;
                    }

                    var releasePath = Path.Combine(this.ReleaseDirectory, file);

                    this.InfoListBox.Items.Add($"{++count}\t{file}");
                    var checksum = dict.Value;
                    if (this.snapshotChecksumDictionary.ContainsKey(file))
                    {
                        var probeChecksum = this.snapshotChecksumDictionary[file];
                        if (probeChecksum != checksum)
                        {
                            var probePath = Path.Combine(this.SnapshotDirectory, file);
                            List<string> releaseErrorList;
                            var releaseCompareResult = this.DllCompare(releasePath, probePath, out releaseErrorList);
                            if (!releaseCompareResult)
                            {
                                var debugPath = Path.Combine(this.DebugDirectory, file);
                                if (File.Exists(debugPath))
                                {
                                    List<string> debugErrorList;
                                    var debugCompareResult = this.DllCompare(debugPath, probePath, out debugErrorList);
                                    if (debugCompareResult)
                                    {
                                        this.InfoListBox.Items.Add("\t\tDEBUG edition!");
                                    }
                                    else
                                    {
                                        this.InfoListBox.Items.Add("\t\tError!");
                                        foreach (var error in releaseErrorList)
                                        {
                                            this.InfoListBox.Items.Add($"\t\t{error}");
                                        }
                                    }
                                }
                                else
                                {
                                    this.InfoListBox.Items.Add("\t\tError!");
                                    foreach (var error in releaseErrorList)
                                    {
                                        this.InfoListBox.Items.Add($"\t\t{error}");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.InfoListBox.Items.Add("\t\tProbe not found!");
                    }

                    this.InfoListBox.Refresh();
                    this.MainProgressBar.Value++;
                    var progress = Math.Round(100m * this.MainProgressBar.Value / this.MainProgressBar.Maximum, 0);
                    this.ProgressLabel.Text = $"{progress} %";
                    this.MainStatusStrip.Refresh();
                    if (count == 2)
                    {
                       // break;
                    }
                }

                var logFileName = Path.Combine(this.SnapshotDirectory, "dllcheck.log");
                if (File.Exists(logFileName))
                {
                    File.Delete(logFileName);
                }

                foreach (string line in this.InfoListBox.Items)
                {
                    File.AppendAllLines(logFileName, new List<string> { line });
                }

                this.MainProgressBar.Value = 0;
                this.ProgressLabel.Text = @"100 %";
                this.MainStatusStrip.Refresh();
                this.MainStatusLabel.Text = @"Завершено!";
            }
            catch (Exception ex)
            {
                this.InfoListBox.Items.Add(ex.Message);
            }
        }

        /// <summary>
        /// The compute m d 5 checksum.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string ComputeMD5Checksum(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                var result = BitConverter.ToString(checkSum).Replace("-", string.Empty);
                return result;
            }
        }

        public bool DllCompare(string srcPath, string dstPath, out List<string> errorList)
        {
            errorList = new List<string>();
            string[] separators = { "\r\n" };

            var module = ModuleDefinition.ReadModule(srcPath);
            var typeFullNameList = (from type in module.Types where type.IsPublic select type.FullName).ToList();

            var dllequal = true;
            foreach (var typeFullName in typeFullNameList)
            {
                try
                {
                    var name = new FullTypeName(typeFullName);
                    var decompiler1 = new CSharpDecompiler(srcPath, new ICSharpCode.Decompiler.DecompilerSettings());
                    var x1 = decompiler1.DecompileTypeAsString(name);
                    var lines1 = x1.Split(separators, StringSplitOptions.None);

                    var decompiler2 = new CSharpDecompiler(dstPath, new ICSharpCode.Decompiler.DecompilerSettings());
                    var x2 = decompiler2.DecompileTypeAsString(name);
                    var lines2 = x2.Split(separators, StringSplitOptions.None);

                    if (lines1.Length != lines2.Length)
                    {
                        dllequal = false;
                        errorList.Add("\t" + srcPath + "\t" + typeFullName + "\t" + "(decompilable)");
                        continue;
                    }

                    if (!lines1.Where((t, i) => t != lines2[i]).Any())
                    {
                        continue;
                    }

                    dllequal = false;
                    errorList.Add("\t" + srcPath + "\t" + typeFullName + "\t" + "(decompilable)");
                }
                catch (Exception ex)
                {
                    errorList.Add("\t\t" + ex.Message);
                    return false;
                }

            }

            return dllequal;
        }

        /// <summary>
        /// The append text.
        /// </summary>
        /// <param name="rtb">
        /// The rtb.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="color">
        /// The color.
        /// </param>
        /// <param name="backColor">
        /// The back color.
        /// </param>
        public void AppendText(RichTextBox rtb, string text, Color color, Color backColor)
        {
            var startText = rtb.TextLength;
            var x = $"{rtb.Lines.Length:0000} ";
            rtb.AppendText(x + text + new string(' ', 1000) + Environment.NewLine);
            rtb.SelectionStart = startText;
            rtb.SelectionLength = rtb.TextLength - startText;
            rtb.SelectionColor = color;
            rtb.SelectionBackColor = backColor;
            rtb.ScrollToCaret();
        }

        public void ViewDiff(string probeText, string srcText)
        {
            var diffBuilder = new InlineDiffBuilder(new Differ());
            var diff = diffBuilder.BuildDiffModel(probeText, srcText);
            this.OldRichTextBox.Clear();
            this.NewRichTextBox.Clear();
            this.MainProgressBar.Maximum = diff.Lines.Count;
            this.MainProgressBar.Value = 0;
            foreach (var line in diff.Lines)
            {
                switch (line.Type)
                {
                    case ChangeType.Inserted:
                        this.AppendText(this.OldRichTextBox, "  ", Color.Red, Color.White);
                        this.AppendText(this.NewRichTextBox, "+ " + line.Text, Color.Green, Color.DarkSeaGreen);
                        break;
                    case ChangeType.Deleted:
                        this.AppendText(this.OldRichTextBox, "- " + line.Text, Color.White, Color.Red);
                        this.AppendText(this.NewRichTextBox, "  ", Color.Black, Color.White);
                        break;
                    default:
                        this.AppendText(this.OldRichTextBox, "   " + line.Text, Color.Black, Color.LightBlue);
                        this.AppendText(this.NewRichTextBox, "   " + line.Text, Color.Black, Color.LightBlue);
                        break;
                }

                this.MainProgressBar.Value++;
                var progress = Math.Round(100m * this.MainProgressBar.Value / this.MainProgressBar.Maximum, 0);
                this.ProgressLabel.Text = $"{progress} %";
                this.MainStatusStrip.Refresh();
            }

            this.MainProgressBar.Value = 0;
            this.ProgressLabel.Text = @"100 %";
            this.MainStatusStrip.Refresh();
            this.MainStatusLabel.Text = @"Завершено!";
        }

        private void ClipboardButtonClick(object sender, EventArgs e)
        {
            var msg = this.InfoListBox.Items.Cast<object>().Aggregate(string.Empty, (current, item) => current + (item + "\r\n"));
            if (!string.IsNullOrEmpty(msg))
            {
                Clipboard.SetText(msg);
            }
        }

        private void DecompileButtonClick1(object sender, EventArgs e)
        {

            string[] separators = { "\t" };
            var selecterString = this.InfoListBox.SelectedItem.ToString();
            var part = selecterString.Split(separators, StringSplitOptions.None);
            if ((part.Length == 6) && (part[5] == "(decompilable)"))
            {
                this.CheckButton.Enabled = false;
                var probePath = part[3];
                var fileName = Path.GetFileName(probePath);
                if (fileName != null)
                {
                    var snapshotPath = Path.Combine(this.SnapshotDirectory, fileName);
                    var typeFullName = part[4];
                    this.SrcDirLabel.Text = snapshotPath;
                    this.ProbeDirLabel.Text = probePath;

                    var name = new FullTypeName(typeFullName);

                    var snapshotDecompiler = new CSharpDecompiler(snapshotPath, new ICSharpCode.Decompiler.DecompilerSettings());
                    var probeDecompiler = new CSharpDecompiler(probePath, new ICSharpCode.Decompiler.DecompilerSettings());

                    var snapshotText = snapshotDecompiler.DecompileTypeAsString(name);
                    var probeText = probeDecompiler.DecompileTypeAsString(name);

                    this.ViewDiff(probeText, snapshotText);

                    this.tabControl1.SelectedIndex = 1;
                }

            }
            else
            {
                MessageBox.Show(@"Поставьте курсор на строку, помеченную (decompilable) и нажмите Decompile", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static string GetDirectory(string selectedPath = "")
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = selectedPath;
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
            }

            return selectedPath;
        }

        private void SrcPathButtonClick(object sender, EventArgs e)
        {
            this.SrcDirectoryTextBox.Text = GetDirectory(this.SrcDirectoryTextBox.Text);
        }

        private void SnapshotPathButtonClick(object sender, EventArgs e)
        {
            this.SnapshotDirectoryTextBox.Text = GetDirectory(this.SnapshotDirectoryTextBox.Text);
        }

        private void ReleasePathButtonClick(object sender, EventArgs e)
        {
            this.ReleaseDirectoryTextBox.Text = GetDirectory(this.ReleaseDirectoryTextBox.Text);
        }

        private void DebugPathButtonClick(object sender, EventArgs e)
        {
            this.DebugDirectoryTextBox.Text = GetDirectory(this.DebugDirectoryTextBox.Text);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }

    internal class Cmp : IEqualityComparer<DllMethodInfo>
    {
        public bool Equals(DllMethodInfo x, DllMethodInfo y)
        {
            if (y != null && x != null && x.Method == y.Method)
            {
                return true;
            }
            
            return false;
        }

        public int GetHashCode(DllMethodInfo obj)
        {
            return base.GetHashCode();
        }
    }
  }