```cs
interface Ciphering {
    string Encryption(string text);
    string Decryption(string text);
}

class CeasarCipherAlgorithm : Ciphering {
    public string Encryption(string text) {
        // Implement Caesar cipher encryption logic
    }

    public string Decryption(string text) {
        // Implement Caesar cipher decryption logic
    }
}

class TheMessage {
    public string plaintext { get; private set; } // The readable text is called 'plaintext' in cryptography
    private Ciphering algorithmOfCipher;

    public TheMessage(string text, Ciphering cipher) {
        plaintext = text;
        algorithmOfCipher = cipher;
    }

    public void ChangePlaintextValue(string text) {
        plaintext = text;
    }

    public void AdjustCipher(Ciphering cipher) {
        algorithmOfCipher = cipher;
    }

    public string EncryptTheMessage() {
        return algorithmOfCipher.Encryption(plaintext); // Returns the ciphertext (the encrypted text)
    }
}

```


Nakodiraj jedan primjer čvrste sprege i jedan primjer labave sprege.