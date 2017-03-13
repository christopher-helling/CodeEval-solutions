import java.io.*;
import java.util.*;


public class Main {
    public static void main (String[] args) throws IOException {
    	int largestInput = 0;
        List<Integer> primesFound = new ArrayList<Integer>();
        primesFound.add(2);
        
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here

            int currentInput = Integer.parseInt(line);
            StringBuilder result = new StringBuilder();
            
            
            if (currentInput > largestInput)
            {
                // this is now our largest input
                largestInput = currentInput;

                for (int prime : primesFound)
                {
                    result.append(prime).append(","); // add the primes we've found so far
                }


                // then calculate more primes
                int firstPrimeCandidate = (primesFound.get(primesFound.size() - 1) % 2 == 0) ? primesFound.get(primesFound.size() - 1) + 1 : primesFound.get(primesFound.size() - 1); // check if last prime found is even (2), then start at the next odd

                for (int primeCandidate = firstPrimeCandidate; primeCandidate < currentInput; primeCandidate += 2) // want first 1000 primes, don't check even numbers
                {
                    boolean isPrime = true;

                    for (int prime : primesFound)
                    {
                        if (primeCandidate % prime == 0) // if our number is divisible by a smaller prime, it is not prime itself
                        {
                            isPrime = false;
                            break; // stop checking further primes
                        }
                    }
                    if (isPrime)
                    {
                        primesFound.add(primeCandidate); // add it to our list of primes
                        result.append(primeCandidate).append(","); // print it to the current result
                    }
                }

            }
            else // we have already discovered this list of primes, and need to return a slice of the list
            {
                for (int prime : primesFound)
                {
                    // only print primes < currentInput
                    if (prime >= currentInput)
                    {
                        break;
                    }
                    else
                    {
                        result.append(prime).append(","); // we will later remove the final comma
                    }
                }
            }



            if (result.length() > 0)
            {
                result.setLength(result.length() - 1); // delete superfluous comma from last prime
            }
            System.out.println(result); // print list of primes
            
        }
        
        buffer.close();
    }
    
    
    
}
