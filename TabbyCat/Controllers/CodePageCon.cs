﻿namespace TabbyCat.Controllers
{
    using FastColoredTextBoxNS;
    using Properties;
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Types;
    using Utils;
    using Languages = FastColoredTextBoxNS.Language;

    /// <summary>
    /// FastColoredTextBox controller class.
    /// Adds GLSL to list of supported languages.
    /// </summary>
    public partial class CodePageCon
    {
        // Constructors

        public CodePageCon(FastColoredTextBox textBox)
        {
            TextBox = textBox ?? throw new NullReferenceException(Resources.Text_ParameterCannotBeNull.Format(nameof(textBox)));
            Init();
        }

        // Private fields

        private AutocompleteMenu _autocompleteMenu;

        private string _textBoxLanguage;

        // Private properties

        private string Language
        {
            get => _textBoxLanguage;
            set => SetLanguage(value);
        }

        private FastColoredTextBox TextBox { get; }

        // Private static properties

        private static readonly MarkerStyle
            SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private static readonly ReadOnlyStyle
            ReadOnlyStyle = new ReadOnlyStyle();

        private static readonly TextStyle
            CommentStyle = NewTextStyle(),
            DirectiveStyle = NewTextStyle(),
            FunctionStyle = NewTextStyle(),
            KeywordStyle = NewTextStyle(),
            NumberStyle = NewTextStyle(),
            ReadOnlyTextStyle = NewTextStyle(),
            ReservedWordStyle = NewTextStyle(),
            StringStyle = NewTextStyle();

        private static TextStyle NewTextStyle() => new TextStyle(Brushes.Black, Brushes.Transparent, 0);

        // Public methods

        public void AddSystemRange(Range range)
        {
            if (range == null)
                return;
            var rangeAll = TextBox.Range;
            if (range.End.iLine > rangeAll.End.iLine)
                range.End = rangeAll.End;
            range.SetStyle(ReadOnlyStyle);
            range.SetStyle(ReadOnlyTextStyle);
        }

        // Private methods

        private void CreateAutocompleteMenu()
        {
            _autocompleteMenu = new AutocompleteMenu(TextBox)
            {
                MinFragmentLength = 2,
                SearchPattern = "[#\\w\\.]" // Directives begin with '#'.
            };
            _autocompleteMenu.Items.SetAutocompleteItems(GLSL.AutocompleteItems);
            _autocompleteMenu.Items.MaximumSize = new Size(200, 300);
            _autocompleteMenu.Items.Width = 200;
        }

        private Languages GetLanguage() => GetLanguage(Language);

        private void Init()
        {
            Language = "GLSL";
            TextBox.HotkeysMapping.Remove(Keys.Control | Keys.R);
            TextBox.HotkeysMapping.Add(Keys.Control | Keys.Y, FCTBAction.Redo);
            TextBox.KeyDown += TextBox_KeyDown;
            TextBox.PaintLine += TextBox_PaintLine;
            TextBox.TextChanged += TextBox_TextChanged;
            TextBox.TextChanging += TextBox_TextChanging;
            CreateAutocompleteMenu();
            TextBox_TextChanged(this, new TextChangedEventArgs(TextBox.Range));
        }

        private void SetLanguage(string language)
        {
            if (Language == language)
                return;
            _textBoxLanguage = language;
            InitStylesPriority(TextBox);
            TextBox.Language = GetLanguage();
            if (Language == "GLSL")
            {
                TextBox.CommentPrefix = "//";
                TextBox.OnTextChanged();
            }
            TextBox.OnSyntaxHighlight(new TextChangedEventArgs(TextBox.Range));
        }

        private void SyntaxHighlightGLSL(TextChangedEventArgs e)
        {
            TextBox.LeftBracket = '(';
            TextBox.RightBracket = ')';
            TextBox.LeftBracket2 = '\x0';
            TextBox.RightBracket2 = '\x0';
            ApplyStylesGLSL(e.ChangedRange);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.K:
                    // forced show (MinFragmentLength will be ignored)
                    _autocompleteMenu.Show(true);
                    e.Handled = true;
                    break;
            }
        }

        private void TextBox_PaintLine(object sender, PaintLineEventArgs e)
        {
            if (new Range(TextBox, e.LineIndex).ReadOnly)
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.LineRect);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Language == "GLSL")
                SyntaxHighlightGLSL(e);
            if (TextBox.Text.Trim().StartsWith("<?xml", ignoreCase: false, CultureInfo.InvariantCulture))
            {
                TextBox.Language = Languages.XML;
                InitStylesPriority(TextBox);
                TextBox.OnSyntaxHighlight(new TextChangedEventArgs(TextBox.Range));
            }
        }

        private void TextBox_TextChanging(object sender, TextChangingEventArgs e)
        {
            var selection = TextBox.Selection;
            e.Cancel = selection.IsReadOnlyLeftChar() || selection.IsReadOnlyRightChar();
        }

        // Private static methods

        public static void ApplyStyles(TextStyleInfos styles)
        {
            if (styles == null)
                return;
            InitStyle(styles.Comments, CommentStyle);
            InitStyle(styles.Directives, DirectiveStyle);
            InitStyle(styles.Functions, FunctionStyle);
            InitStyle(styles.Keywords, KeywordStyle);
            InitStyle(styles.Numbers, NumberStyle);
            InitStyle(styles.ReadOnly, ReadOnlyTextStyle);
            InitStyle(styles.ReservedWords, ReservedWordStyle);
            InitStyle(styles.Strings, StringStyle);
        }

        private static void ApplyStylesGLSL(Range range)
        {
            range.ClearStyle(
                CommentStyle,
                DirectiveStyle,
                FunctionStyle,
                KeywordStyle,
                NumberStyle,
                ReservedWordStyle,
                StringStyle);
            range.SetStyle(StringStyle, GLSL.Strings);
            range.SetStyle(CommentStyle, GLSL.Comments1, RegexOptions.Multiline);
            range.SetStyle(CommentStyle, GLSL.Comments2, RegexOptions.Singleline);
            range.SetStyle(CommentStyle, GLSL.Comments3, RegexOptions.Singleline | RegexOptions.RightToLeft);
            range.SetStyle(NumberStyle, GLSL.Numbers);
            range.SetStyle(FunctionStyle, GLSL.Functions);
            range.SetStyle(KeywordStyle, GLSL.Keywords);
            range.SetStyle(ReservedWordStyle, GLSL.ReservedWords);
            range.SetStyle(DirectiveStyle, GLSL.Directives);
            range.ClearFoldingMarkers();
            range.SetFoldingMarkers("{", "}");
            range.SetFoldingMarkers(@"/\*", @"\*/");
        }

        private static Languages GetLanguage(string language)
        {
            switch (language)
            {
                case "C#": return Languages.CSharp;
                case "GLSL": return Languages.Custom;
                case "HTML": return Languages.HTML;
                case "JS": return Languages.JS;
                case "Lua": return Languages.Lua;
                case "PHP": return Languages.PHP;
                case "SQL": return Languages.SQL;
                case "VB": return Languages.VB;
                case "XML": return Languages.XML;
                default: return Languages.Custom;
            }
        }

        private static void InitStyle(TextStyleInfo info, TextStyle style)
        {
            if (((SolidBrush)style.ForeBrush).Color != info.Foreground)
                style.ForeBrush = info.Foreground.ToSolidBrush();
            if (((SolidBrush)style.BackgroundBrush).Color != info.Background)
                style.BackgroundBrush = info.Background.ToSolidBrush();
            style.FontStyle = info.FontStyle;
        }

        private static void InitStylesPriority(FastColoredTextBox textBox)
        {
            textBox.ClearStylesBuffer();
            textBox.Range.ClearStyle(StyleIndex.All);
            textBox.AddStyle(SameWordsStyle);
            textBox.AddStyle(ReadOnlyTextStyle);
            textBox.AddStyle(StringStyle);
            textBox.AddStyle(CommentStyle);
            textBox.AddStyle(NumberStyle);
            textBox.AddStyle(FunctionStyle);
            textBox.AddStyle(KeywordStyle);
            textBox.AddStyle(ReservedWordStyle);
            textBox.AddStyle(DirectiveStyle);
        }
    }

    public partial class CodePageCon : IDisposable
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _autocompleteMenu?.Dispose();
                TextBox?.Dispose();
            }
            _disposed = true;
        }
    }
}
