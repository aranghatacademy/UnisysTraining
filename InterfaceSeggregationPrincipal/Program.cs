using InterfaceSeggregationPrincipal;

IAudioPlayer tv = new TV();
tv.PlayAudio("song.mp3");

IVideoPlayer tv2 = new TV();
tv2.PlayVideo("movie.mp4", "1080p");