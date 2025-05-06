using System.ComponentModel.DataAnnotations;

namespace AiPlayground.Core.Models;
public enum LlmModel
{
    [Display(Name = "deepseek-r1:1.5b")]
    DeepSeek_R1_1_5b,

    [Display(Name = "llama3")]
    Llama3
}