using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class MatchingExercise : MonoBehaviour
{
    [SerializeField] private MatchingGameManager matchingGameManager; 
    void Start()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void GeneratePdf()
    {
        List<WordDataScriptable> words = GameManager.Instance.GetExerciseWords().ToList();
        List<string> syllables = matchingGameManager.GetExerciseSyllables().ToList(); 
        syllables.Shuffle();
        words.Shuffle(); 

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Content().Column(column =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(16));

                    column.Item().Row(row =>
                    {
                        row.RelativeItem().AlignLeft().Text("Prénom : .................");
                        row.RelativeItem().AlignRight().Text("Date : .................");
                    });

                    column.Item().PaddingBottom(20);

                    column.Item().Border(1).Padding(5).AlignCenter().Text("Lire des syllabes").FontSize(14);
                    column.Item().PaddingBottom(15);
                    
                    column.Item().PaddingBottom(20);

                    column.Item().AlignCenter().Row(row =>
                    {
                        row.Spacing(150);

                        row.AutoItem().AlignMiddle().Column(left =>
                        {
                            foreach (string syllable in syllables)
                                left.Item().PaddingVertical(15).Row(entry =>
                                {
                                    entry.ConstantItem(60).Text(syllable);
                                    entry.ConstantItem(20).AlignMiddle().Text("●");
                                });
                        });

                        row.AutoItem().AlignMiddle().Column(right =>
                        {
                            foreach (WordDataScriptable word in words)
                                right.Item().PaddingVertical(15).Row(entry =>
                                {
                                    entry.ConstantItem(20).AlignMiddle().Text("●");

                                    entry.ConstantItem(90).Column(item =>
                                    {
                                        item.Item().AlignCenter().AlignMiddle().Width(70).Height(70).Image(Helpers.SpriteToPng(word.image)).FitArea();
                                    });
                                });
                        });
                    });
                });
            });
        })
        .GeneratePdf(Path.Combine(Helpers.GetDownloadsPath(), "matching_exercise.pdf"));
    }
}
