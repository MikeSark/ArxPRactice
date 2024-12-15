fn merge_words(word1: &str, word2: &str) -> String {
    let mut result = String::with_capacity(word1.len() + word2.len());
    let length1 = word1.len();
    let length2 = word2.len();

    for i in 0..length1.max(length2) {
        if i < length1 {
            result.push(word1.chars().nth(i).unwrap());
        }
        if i < length2 {
            result.push(word2.chars().nth(i).unwrap());
        }
    }

    result
}

fn main() {
    let word1 = "abc";
    let word2 = "xyz";
    let merged = merge_words(word1, word2);
    println!("{}", merged); // Output: "axbycz"
}

