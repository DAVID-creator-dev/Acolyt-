using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class WriteSyllablesExercise : MonoBehaviour
{
    void Start()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void GeneratePdf()
    {
        List<WordDataScriptable> words = GameManager.Instance.GetExerciseWords().ToList();
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
                    column.Item().Border(1).Padding(5).AlignCenter().Text("SYLLABES - MOTS").FontSize(14).Bold();
                    column.Item().PaddingBottom(15);

                    column.Item().Row(entry =>
                    {
                        entry.ConstantItem(20).Text("●");
                        entry.AutoItem().Text("Lis les syllabes.");
                    });

                    column.Item().Row(entry =>
                    {
                        entry.ConstantItem(20).Text("●");
                        entry.AutoItem().Text("Relie chaque syllabe à son image.");
                    }); 
                    column.Item().PaddingBottom(20);

                    
                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(120); 
                            columns.RelativeColumn();    
                        });

                        foreach (WordDataScriptable word in words)
                        {
                            table.Cell().Border(1).Column(inner =>
                            {
                                inner.Item().BorderBottom(1).Padding(5).AlignCenter().Height(70).Image(Helpers.SpriteToPng(word.image)).FitArea();
                                inner.Item().Padding(5).AlignCenter().Text("X X"); // nombre de syllabes, à rendre dynamique plus tard
                            });

                            table.Cell().Border(1); // rien dedans, juste le cadre pour écrire
                        }
                    }); 

                    /*
                    // TODO: remplacer par la liste fournie par WriteSyllablesManager une fois définie
                    List<string> syllables = new List<string> { "re", "ri", "ro", "ru" };

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (string syllable in syllables)
                                columns.RelativeColumn();
                        });

                        foreach (string syllable in syllables)
                            table.Cell().Border(1).Padding(5).AlignCenter().Text(syllable).FontSize(20);

                        foreach (string syllable in syllables)
                            table.Cell().Border(1).Padding(5).Height(60);
                    });
                    */
                });
            });
        })
        .GeneratePdf(Path.Combine(Application.persistentDataPath, "test.pdf"));
    }
}
