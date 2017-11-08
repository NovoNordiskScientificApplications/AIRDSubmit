using AIRDsubmit.AIRD.Service;
using AIRDsubmit.Properties;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace AIRDsubmit
{
    class ExcelViewModel
    {
        private string DB_PATH;

        public ObservableCollection<RecordViewModel> Records { get; private set; }

        public ExcelViewModel(string filePath)
        {
            DB_PATH = filePath;
        }

        public void Load()
        {
            var mismatches = new Dictionary<string, string>();
            Records = new ObservableCollection<RecordViewModel>();
            using(var excelPackage = new ExcelPackage(new FileInfo(DB_PATH)))
            using(var excelWorkBook = excelPackage.Workbook)
            using(var excelWorksheet = excelWorkBook.Worksheets.First())
            {

                foreach(var column in ColumnNames)
                {
                    string c = excelWorksheet.Cells[1, column.Value].Value?.ToString();
                    if(string.IsNullOrEmpty(c))
                        excelWorksheet.Cells[1, column.Value].Value = column.Key;
                    else if(!string.Equals(c, column.Key, StringComparison.InvariantCultureIgnoreCase))
                        mismatches.Add(column.Key, c);
                }
                excelPackage.Save();

                for(int i = 2; i <= excelWorksheet.Dimension.End.Row; i++)
                {
                    var r = new RecordViewModel();
                    r.Row = i;
                    r.Permission = excelWorksheet.Cells[i, (int)ColumnIndex.Permission].Value?.ToString();
                    r.Species = excelWorksheet.Cells[i, (int)ColumnIndex.Species].Value?.ToString();
                    r.SpeciesOther = excelWorksheet.Cells[i, (int)ColumnIndex.SpeciesOther].Value?.ToString();
                    int Number;
                    if(int.TryParse(excelWorksheet.Cells[i, (int)ColumnIndex.Number].Value?.ToString(), out Number))
                        r.Number = Number;
                    r.Reuse = excelWorksheet.Cells[i, (int)ColumnIndex.Reuse].Value?.ToString();
                    r.PlaceOfBirth = excelWorksheet.Cells[i, (int)ColumnIndex.PlaceOfBirth].Value?.ToString();
                    r.NHPSource = excelWorksheet.Cells[i, (int)ColumnIndex.NHPSource].Value?.ToString();
                    r.NHPGeneration = excelWorksheet.Cells[i, (int)ColumnIndex.NHPGeneration].Value?.ToString();
                    r.GeneticStatus = excelWorksheet.Cells[i, (int)ColumnIndex.GeneticStatus].Value?.ToString();
                    r.CreationOfGeneticLine = excelWorksheet.Cells[i, (int)ColumnIndex.CreationOfGeneticLine].Value?.ToString();
                    r.Purpose = excelWorksheet.Cells[i, (int)ColumnIndex.Purpose].Value?.ToString();
                    r.PurposeOther = excelWorksheet.Cells[i, (int)ColumnIndex.PurposeOther].Value?.ToString();
                    r.TestingByLegislation = excelWorksheet.Cells[i, (int)ColumnIndex.TestingByLegislation].Value?.ToString();
                    r.TestingByLegislationOther = excelWorksheet.Cells[i, (int)ColumnIndex.TestingByLegislationOther].Value?.ToString();
                    r.LegislativeRequirements = excelWorksheet.Cells[i, (int)ColumnIndex.LegislativeRequirements].Value?.ToString();
                    r.Severity = excelWorksheet.Cells[i, (int)ColumnIndex.Severity].Value?.ToString();
                    r.CustomSeverity = excelWorksheet.Cells[i, (int)ColumnIndex.CustomSeverity].Value?.ToString();
                    r.Comments1 = excelWorksheet.Cells[i, (int)ColumnIndex.Comments1].Value?.ToString();
                    r.Comments2 = excelWorksheet.Cells[i, (int)ColumnIndex.Comments2].Value?.ToString();
                    int Year;
                    if(int.TryParse(excelWorksheet.Cells[i, (int)ColumnIndex.Year].Value?.ToString(), out Year))
                        r.Year = Year;
                    else if(int.TryParse(App.Settings["DefaultYear"], out Year))
                        r.Year = Year;
                    bool Uploaded;
                    if(bool.TryParse(excelWorksheet.Cells[i, (int)ColumnIndex.Uploaded].Value?.ToString(), out Uploaded))
                        r.Uploaded = Uploaded;

                    r.PropertyChanged += R_PropertyChanged;

                    Records.Add(r);
                }
            }
            if(mismatches.Any())
            {
                throw new Exception("Some columns did not match the expected columns\n" +
                    string.Join("\n", mismatches.Select(c => string.Format(@"Expected ""{0}"". Found ""{1}""", c.Key, c.Value))));
            }
        }
        
        public void Update(RecordViewModel record)
        {
            using(var excelPackage = new ExcelPackage(new System.IO.FileInfo(DB_PATH)))
            using(var excelWorkBook = excelPackage.Workbook)
            using(var excelWorksheet = excelWorkBook.Worksheets.First())
            { 
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Permission].Value = record.Permission;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Species].Value = record.Species;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.SpeciesOther].Value = record.SpeciesOther;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Number].Value = record.Number;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Reuse].Value = record.Reuse;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.PlaceOfBirth].Value = record.PlaceOfBirth;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.NHPSource].Value = record.NHPSource;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.NHPGeneration].Value = record.NHPGeneration;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.GeneticStatus].Value = record.GeneticStatus;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.CreationOfGeneticLine].Value = record.CreationOfGeneticLine;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Purpose].Value = record.Purpose;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.PurposeOther].Value = record.PurposeOther;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.TestingByLegislation].Value = record.TestingByLegislation;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.TestingByLegislationOther].Value = record.TestingByLegislationOther;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.LegislativeRequirements].Value = record.LegislativeRequirements;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Severity].Value = record.Severity;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.CustomSeverity].Value = record.CustomSeverity;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Comments1].Value = record.Comments1;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Comments2].Value = record.Comments2;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Year].Value = record.Year;
                excelWorksheet.Cells[record.Row, (int)ColumnIndex.Uploaded].Value = record.Uploaded;
                excelPackage.Save();
            }
        }

        public void Upload(string Username, string Password)
        {
            var st = new StatisticsReportingSoapClient();
            var auth = new AuthInfo();
            auth.UserName = Username;
            auth.Password = Password;
            try
            {
                st.Open();

                foreach(RecordViewModel r in Records)
                {
                    if(!r.Uploaded)
                    {
                        try
                        {
                            // Ensure that the excel database is writable before continuing
                            Update(r);

                            var reportingInfo = RecordMapper.RecordToReportingInfo(r.Record);
                            var response = st.Add(auth, reportingInfo);

                            if(response.ErrorMessage == null || response.ErrorMessage.IsSuccess)
                            {
                                r.Uploaded = true;
                                r.ErrorMessage = null;
                                Update(r);
                            }
                            else
                            {
                                r.ErrorMessage = string.Format("Upload error (Code {0}): {1}", response.ErrorMessage.Code, response.ErrorMessage.Message);
                            }
                        }
                        catch(Exception e)
                        {
                            r.ErrorMessage = string.Format("Upload error: {0}", e.Message);
                            throw;
                        }
                    }
                }
            }
            finally
            {
                st.Close();
            }
        }

        private void R_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(typeof(Record).GetProperties().Select(s => s.Name).Contains(e.PropertyName))
                try
                {
                    Update(sender as RecordViewModel);
                }
                catch(Exception ex)
                {
                    (sender as RecordViewModel).ErrorMessage = "Save error: " + ex.Message;
                }
        }

        public Dictionary<string, int> ColumnNames = new Dictionary<string, int>
        {
            { Resources.ColumnPermission, (int)ColumnIndex.Permission },
            { Resources.ColumnSpecies, (int)ColumnIndex.Species },
            { Resources.ColumnSpeciesOther, (int)ColumnIndex.SpeciesOther },
            { Resources.ColumnNumber, (int)ColumnIndex.Number },
            { Resources.ColumnReuse, (int)ColumnIndex.Reuse },
            { Resources.ColumnPlaceOfBirth, (int)ColumnIndex.PlaceOfBirth },
            { Resources.ColumnNHPSource, (int)ColumnIndex.NHPSource },
            { Resources.ColumnNHPGeneration, (int)ColumnIndex.NHPGeneration },
            { Resources.ColumnGeneticStatus, (int)ColumnIndex.GeneticStatus },
            { Resources.ColumnCreationOfGeneticLine, (int)ColumnIndex.CreationOfGeneticLine },
            { Resources.ColumnPurpose, (int)ColumnIndex.Purpose },
            { Resources.ColumnPurposeOther, (int)ColumnIndex.PurposeOther },
            { Resources.ColumnTestingByLegislation, (int)ColumnIndex.TestingByLegislation },
            { Resources.ColumnTestingByLegislationOther, (int)ColumnIndex.TestingByLegislationOther },
            { Resources.ColumnLegislativeRequirements, (int)ColumnIndex.LegislativeRequirements },
            { Resources.ColumnSeverity, (int)ColumnIndex.Severity },
            { Resources.ColumnCustomSeverity, (int)ColumnIndex.CustomSeverity },
            { Resources.ColumnComments1, (int)ColumnIndex.Comments1 },
            { Resources.ColumnComments2, (int)ColumnIndex.Comments2 },
            { Resources.ColumnYear, (int)ColumnIndex.Year },
            { Resources.ColumnUploaded, (int)ColumnIndex.Uploaded },
        };

        public enum ColumnIndex
        {
            Permission = 2,
            Species = 5,
            SpeciesOther = 6,
            Number = 7,
            Reuse = 8,
            PlaceOfBirth = 9,
            NHPSource = 10,
            NHPGeneration = 11,
            GeneticStatus = 12,
            CreationOfGeneticLine = 13,
            Purpose = 14,
            PurposeOther = 15,
            TestingByLegislation = 16,
            TestingByLegislationOther = 17,
            LegislativeRequirements = 18,
            Severity = 19,
            CustomSeverity = 20,
            Comments1 = 21,
            Comments2 = 22,
            Year = 23,
            Uploaded = 24,
        }

        #region Lists of acceptable values
        public List<string> Species => RecordMapper.SpeciesStringToEnum.Keys.ToList();
        public List<string> Reuse => RecordMapper.ReuseStringToEnum.Keys.ToList();
        public List<string> PlaceOfBirth => RecordMapper.PlaceOfBirthStringToEnum.Keys.ToList();
        public List<string> NHPSource => RecordMapper.NHPSourceStringToEnum.Keys.ToList();
        public List<string> NHPGeneration => RecordMapper.NHPGenerationStringToEnum.Keys.ToList();
        public List<string> Purpose => RecordMapper.PurposeStringToEnum.Keys.ToList();
        public List<string> TestingByLegislation => RecordMapper.TestingByLegislationStringToEnum.Keys.ToList();
        public List<string> LegislativeRequirements => RecordMapper.LegislativeRequirementsStringToEnum.Keys.ToList();
        public List<string> Severity => RecordMapper.SeverityStringToEnum.Keys.ToList();
        public List<string> GeneticStatus => RecordMapper.GeneticStatusStringToEnum.Keys.ToList();
        public List<string> CreationOfGeneticLine => RecordMapper.CreationOfGeneticLineStringToEnum.Keys.ToList();

        #endregion
    }
}
