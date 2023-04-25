/*
    Translate RNA sequences into proteins.

    RNA can be broken into three nucleotide sequences called codons, and then translated to a polypeptide like so:

    RNA: "AUGUUUUCU" => translates to

    Codons: "AUG", "UUU", "UCU" => which become a polypeptide with the following sequence =>

    Protein: "Methionine", "Phenylalanine", "Serine"

    There are 64 codons which in turn correspond to 20 amino acids; however, all of the codon sequences and resulting amino acids are not important in this exercise. If it works for one codon, the program should work for all of them. However, feel free to expand the list in the test suite to include them all.

    There are also three terminating codons (also known as 'STOP' codons); if any of these codons are encountered (by the ribosome), all translation ends and the protein is terminated.

    All subsequent codons after are ignored, like this:

    RNA: "AUGUUUUCUUAAAUG" =>

    Codons: "AUG", "UUU", "UCU", "UAA", "AUG" =>

    Protein: "Methionine", "Phenylalanine", "Serine"

    Note the stop codon "UAA" terminates the translation and the final methionine is not translated into the protein sequence.

    Below are the codons and resulting Amino Acids needed for the exercise.

    Codon	            Protein
    AUG	                Methionine
    UUU, UUC	        Phenylalanine
    UUA, UUG	        Leucine
    UCU, UCC, UCA, UCG	Serine
    UAU, UAC	        Tyrosine
    UGU, UGC	        Cysteine
    UGG	                Tryptophan
    UAA, UAG, UGA	    STOP
*/
public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        string[] proteins = {};
        int index = 0;
        int length = 3;
        bool stop = false;
        
        // ¬(A || B) => Only true when both are false
        while (!(stop || index >= strand.Length))
        {
            string codon = strand.Substring(index, length);
            string protein = codon.Translate();
            stop = protein == "STOP";
            if (!stop)
            {
                proteins = (string[]) proteins.ExtendArray(protein);
            }
            index += length;
        }

        return proteins;
    }

    private static string Translate(this string codon)
    {
        if (codon == "AUG") return "Methionine";
        if (codon == "UUU" || codon == "UUC") return "Phenylalanine";
        if (codon == "UUA" || codon == "UUG") return "Leucine";
        if (codon == "UCU" || codon == "UCC" || codon == "UCA" || codon == "UCG") return "Serine";
        if (codon == "UAU" || codon == "UAC") return "Tyrosine";
        if (codon == "UGU" || codon == "UGC") return "Cysteine";
        if (codon == "UGG") return "Tryptophan";
        if (codon == "UAA" || codon == "UAG" || codon == "UGA") return "STOP";
        
        throw new ArgumentException($"Codon mismatch: {codon}");
    }

    /*
        Use of extensible arrays allows us to dynamically manage its size at the cost of reassigning values from the old array to the new one. This is okay for arrays up to moderate size.
    */
    private static string[] ExtendArray(this string[] oldArray, string lastElem)
    {
        int oldArrayLength = oldArray.Length;
        string[] newArray = new string[oldArrayLength + 1];

        for (int i = 0; i < oldArrayLength; i++)
            newArray[i] = oldArray[i];

        newArray[newArray.Length - 1] = lastElem;

        return newArray;
    }
}