# Acolyt-

> 🚧 Project under active development. The features listed below are still being finalized and subject to change.

## Overview

Acolyt- is a Unity application for teachers/parents to build reading and phonics worksheets for young children (words, syllables, sentences), then export them as printable PDFs via [QuestPDF](https://www.questpdf.com/).

The general flow: pick words from a library (each tied to an image and its syllable breakdown), then choose an exercise type based on that selection. Each exercise has its own parameters and generates its own PDF sheet, ready to print.

## Features (v1.0)

- **Word selection** — a library of words (image + syllables) defined as ScriptableObjects, shared across all exercises.
- **"Match syllable to word" exercise** — select syllables from the chosen words, generates a two-column sheet (syllables / images) to connect with a line.
- **"Circle the letters" exercise** — enter target letters, generates a sheet listing the selected words with the instruction to circle those letters.
- **"Write the syllables" exercise** — generates a sheet with, for each selected word, its picture and a blank space to write the missing syllable.
- **"Write the sentences" exercise** — select sentences organized by lesson (word by word, syllable by syllable), generates a sheet with a paste zone, syllable markers, and a bank of cut-out tiles.
- **PDF generation** — export each exercise as a print-ready PDF via QuestPDF.

## Demonstration

| Step 1 | Step 2 | Final PDF result |
| --- | --- | --- |
| ![Step 1](docs/images/step1.png) | ![Step 2](docs/images/step2.png) | ![Final PDF result](docs/images/result.png) |
