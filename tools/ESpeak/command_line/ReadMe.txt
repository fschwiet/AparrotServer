This is a version of eSpeak which can be run from the Command Prompt.
It does not use the Microsoft SAPI5 speech interface.

For details, see docs/commands.html or do the command:
  espeak --help

To list the available voices, do:
  espeak --voices

It can speak text directly with:
  espeak -v en "hello"
or
  espeak -v en -f textfile.txt

It can write the sound output to a WAV file.
  espeak -w test.wav "hello"

It can also compile the spelling-to-phoneme translation data
(in C:\Program Files\eSpeak\dictsource) for a language by doing:
  espeak --compile=en

where "en" can be replaced by the code for the required language.
