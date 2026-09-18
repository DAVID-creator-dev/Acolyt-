using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class WriteSentenceExercise : MonoBehaviour
{
    [SerializeField] private WriteSentencesManager writeSentenceExercise; 

    void Start()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void GeneratePdf()
    {
        List<Sentence> sentences = writeSentenceExercise.GetExerciseSentenes().ToList();

        List<string> syllableTiles = sentences
            .SelectMany(sentence => sentence.words)
            .SelectMany(word => word.syllables)
            .ToList();
        syllableTiles.Shuffle();

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

                    column.Item().Border(1).Padding(5).AlignCenter().Text("Écrire les phrases").FontSize(14);
                    column.Item().PaddingBottom(15);

                    foreach (Sentence sentence in sentences)
                    {
                        column.Item().Border(1).Column(block =>
                        {
                            block.Item().Height(80);

                            block.Item().BorderTop(1).Padding(5).Inlined(wordsWrap =>
                            {
                                wordsWrap.Spacing(20);

                                foreach (Word word in sentence.words)
                                    wordsWrap.Item().Row(syllablesRow =>
                                    {
                                        foreach (string syllable in word.syllables)
                                            syllablesRow.AutoItem().AlignCenter().Text("⌣").FontColor(Colors.Blue.Medium).FontSize(24);
                                    });
                            });
                        });

                        column.Item().PaddingBottom(15);
                    }

                    column.Item().PaddingTop(10);

                    column.Item().Inlined(bank =>
                    {
                        bank.Spacing(10);

                        foreach (string tile in syllableTiles)
                            bank.Item().Border(1).Padding(10).AlignCenter().Text(tile);
                    });
                });
            });
        })
        .GeneratePdf(Path.Combine(Helpers.GetDownloadsPath(), "write_sentences_exercise.pdf"));
    }
}
