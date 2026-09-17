using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using UnityEngine.UIElements;

public class WriteSyllablesExercise : MonoBehaviour
{
    [SerializeField] private WriteSyllablesManager writeSyllablesManager; 
    [SerializeField] private Sprite syllable; 
    [SerializeField] private Sprite syllableCross; 

    void Start()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void GeneratePdf()
    {
        List<WordDataScriptable> words = GameManager.Instance.GetExerciseWords().ToList();
        List<string> syllables = writeSyllablesManager.GetExerciseSyllables().ToList(); 
        words.Shuffle(); 

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(16));

                page.Content().Column(column =>
                {
                    column.Item().Row(row =>
                    {
                        row.RelativeItem().AlignLeft().Text("Prénom : .................");
                        row.RelativeItem().AlignRight().Text("Date : .................");
                    });

                    column.Item().PaddingBottom(20);

                    column.Item().Border(1).Padding(5).AlignCenter().Text("Écrire des syllabes").FontSize(14);
                    column.Item().PaddingBottom(15);
                    
                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(100);
                            columns.RelativeColumn();
                        });

                        foreach (WordDataScriptable word in words)
                        {
                            table.Cell().Border(1).Column(inner =>
                            {
                                inner.Item().BorderBottom(1).Padding(5).Height(100).AlignCenter().AlignMiddle().Image(Helpers.SpriteToPng(word.image)).FitArea();
                                
                                inner.Item().AlignCenter().Row(row =>
                                {
                                    foreach(string currentSyllable in word.syllables)
                                    {
                                        if (syllables.Contains(currentSyllable))
                                            row.AutoItem().Width(20).Height(30).PaddingBottom(5).AlignBottom().Image(Helpers.SpriteToPng(syllableCross)).FitArea();
                                        else
                                            row.AutoItem().Width(20).Height(30).PaddingBottom(5).AlignBottom().Image(Helpers.SpriteToPng(syllable)).FitArea();
                                    }
                                });
                            });

                            table.Cell().Border(1); 
                        }
                    }); 

                    column.Item().Extend().AlignBottom().Table(table =>
                    {
                        const int totalColumns = 4;

                        table.ColumnsDefinition(columns =>
                        {
                            for (int i = 0; i < totalColumns; i++)
                                columns.RelativeColumn();
                        });

                        for (int i = 0; i < totalColumns; i++)
                            table.Cell().Border(1).Padding(5).Height(30).AlignCenter().Text(i < syllables.Count ? syllables[i] : "").FontSize(20);

                        for (int i = 0; i < totalColumns; i++)
                            table.Cell().Border(1).Padding(5).Height(30);
                    });
                });
            });
        })
        .GeneratePdf(Path.Combine(Helpers.GetDownloadsPath(), "write_syllables_exercise.pdf"));
    }
}
