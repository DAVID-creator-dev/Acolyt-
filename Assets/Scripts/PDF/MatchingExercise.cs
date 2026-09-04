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
        List<WordDataScriptable> words = matchingGameManager.GetExerciseWords().ToList();
        List<string> syllables = matchingGameManager.GetExerciseSyllables().ToList(); 

        if (words.Count == 0 && syllables.Count == 0)
        {
            Debug.Log("No words selected");
            return;
        }

        syllables.Shuffle(); 
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
                                        item.Item().AlignCenter().Width(70).Height(70).Image(Helpers.SpriteToPng(word.image)).FitArea();
                                    });
                                });
                        });
                    });
                });
            });
        })
        .GeneratePdf(Path.Combine(Application.persistentDataPath, "matching_exercise.pdf"));
    }
}
