# HelloOoba

This is a very bare-bones OpenAI-based OobaBooga client, written mainly as a proof-of-concept to hook in via RestSharp.

The main part of this code was inspired by Steve Fenton's code found here:
https://www.stevefenton.co.uk/blog/2023/01/azure-open-ai-restsharp/

Unfortunately it didn't really work out of the box, so I refactored it into the OpenAI.cs file and calling code you'll see here. I wrote this specifically for interfacing with my local OobaBooga instance, as I said, but it should (knock wood) work with other OpenAI compatible endpoints out there. Note: I haven't included authorization in this code, so bear in mind if you need that you'll have to implment it yourself.
