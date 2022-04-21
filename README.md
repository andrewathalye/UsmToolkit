# UsmToolkit

Tool to convert USM video files into user-friendly formats.

## Getting started

Download the latest version and run `UsmToolkit get-dependencies`. This will download ffmpeg and vgmstream from the URLs provided in `deps.json`. These are neccessary for this tool to operate!

After that, it's as easy as it can get.

### Extracting
```
UsmToolkit extract <file/folder>
```

## Linux Support

I've made some light modifications to prevent usmtoolkit from merging multiple adx files and enable .NET Core 6.0 Linux support.

## Destiny

In order to use this with Destiny, you should convert the adx files to wav using vgmstream-cli before merging using FFMpeg.
You may be able to get away with not doing that, but it seems like the background music adx files are not recognised correctly  
by FFMpeg.

## License

UsmToolkit follows the MIT License. It uses code from [VGMToolbox](https://sourceforge.net/projects/vgmtoolbox/).
