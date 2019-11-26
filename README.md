# WICCop Tool

WICCop is a tool that can be used to validate the correct behaviour of a Windows Imaging Component (WIC) codec.
It was originaly available from <http://code.msdn.microsoft.com/wictools>, but it is not available anymore from that download location.

## Modifications

This Microsoft application has been modified to compile with Visual Studio 2019.

## How to use

- Start the tool
- Open the option dialog (CTRL-O) and select images as test input.
- Select which WIC encoder or decoder to test.
- Press F5 to start the tests.

### Note about 32 bit WIC codecs

The WIC guidelines requires to make a WIC codec available in 32 bit and 64 bit. A WIC codec is a in-process COM component, and a 32 bit version is needed
for 32-bit operating systems and applications. Usage of 32 bit versions of Windows is rare nowadays, but many 32 bit image applications still exists.
To disable 32-bit testing, the WICCop application can be started with -nowow
