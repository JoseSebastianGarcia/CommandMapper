--- SPANISH ---

# CommandMapper

CommandMapper te apoyará en la construcción de tu CLI aplicando el patrón Command. Cada comando registrado será reconocido por reflection (nombre) para mapearlo a la entrada de comandos del ejecutable. Si lo deseas, podrás asignar opciones a cada comando.

## Características Principales

- Facilidad de uso
- Uso de un framework moderno como .NET 8
- Desacople de comandos

## Motivación

Desarrollé este micro-framework buscando algo simple de implementar y que simplifique la creación de CLIs. El problema que resuelve es el parsing de la entrada de argumentos.

## Beneficios

- Código limpio, legible, estándar
- Uso simple e intuitivo
- Patrón definido basado en prácticas probadas

## Instalación

Crea un proyecto de consola con el nombre que prefieras e instala el paquete NuGet CommandMapper.Core.

## Ejemplo Rápido

El ejemplo de implementación ya está disponible y hay una solución demo en el código (consoleapp1).

## Uso Detallado

```csharp
using CommandMapper.CLI.Commands;
using CommandMapper.Core.Services;

namespace CommandMapper.CLI;

public static class Program 
{
    public static void Main(params string[] args) 
    {
        ICommandManager mapper = new CommandManager();

        //consoleapp1 sayhello -n Sebastian
        mapper.Register(new SayHelloCommand()); //CommandBaseWithOptions<T>

        //consoleapp1 sayhour 
        mapper.Register(new SayHourCommand()); //CommandBase


        //CommandName was calculated by reflection deleting 'Command' suffix.

        mapper.Execute(args);
    }
}
```

```csharp
using CommandMapper.CLI.Options;
using CommandMapper.Core.WithOptions;
using System;


namespace CommandMapper.CLI.Commands
{
    public class SayHelloCommand : CommandBaseWithOptions<NameOption>
    {
        protected override void CommandScript(NameOption options)
        {
            Console.WriteLine("Hello {0}!", options.Name);
        }
    }
}
```


```csharp
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.CLI.Options
{
    public class NameOption
    {
        [Option('n', "name", Required = true, HelpText = "El nombre del mono")]
        public string Name { get; set; } = null!;

        [Option('o', "onor", Required = false, HelpText = "Algo que no quiero pasar parametros")]
        public bool OptionX { get; set; }
    }
}
```


```csharp
using CommandMapper.Core.WithoutOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.CLI.Commands
{
    public class SayHourCommand : CommandBase
    {
        protected override void CommandScript()
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}
```

## Opciones y Parámetros

Las opciones y parámetros se configuran siguiendo la estructura de una sola línea: "program <command [options]>".

## Personalización

Extendiendo las interfaces y clases base.

## Contribuciones

- Creación de issues y propuestas de mejoras. (ya identifiqué algunas)
- Código largo y legible sobre corto e ilegible. Estándares de C#. Se aceptan mejoras al código. Desacople. Inversión de dependencias. Claridad estructural. Código fluido.
- Aplicar inyección de dependencias. Reconocimiento automático de comandos mediante reflection. Personalizar el mapeo entre la clase Command y el nombre en el diccionario.

## Soporte

Para preguntas o soporte, puedes contactarme en jose-sebastian.garcia@outlook.com.

## Licencia

MIT

## Agradecimiento

**¡Gracias por tu apoyo!**

Cada contribución, pequeña o grande, me mantiene motivado para seguir desarrollando y mejorando CommandMapper. ¡Tu apoyo me ayuda a mantenerme enfocado y continuar ofreciendo herramientas útiles para la comunidad de desarrolladores!

--- ENGLISH ---

# CommandMapper

CommandMapper will assist you in building your CLI by applying the Command pattern. Each registered command will be recognized by reflection (name) to map it to the executable's command input. If desired, you can assign options to each command.

## Main Features

- Ease of use
- Use of a modern framework like .NET 8
- Decoupling of commands

## Motivation

I developed this micro-framework aiming for something simple to implement and to simplify the creation of CLIs. The problem it solves is parsing command line arguments.

## Benefits

- Clean, readable, standard code
- Simple and intuitive to use
- Defined pattern based on proven practices

## Installation

Create a console project with the name of your choice and install the CommandMapper.Core NuGet package.

## Quick Example

The implementation example is already available, and there is a demo solution in the code (consoleapp1).

## Detailed Usage

```csharp
using CommandMapper.CLI.Commands;
using CommandMapper.Core.Services;

namespace CommandMapper.CLI;

public static class Program 
{
    public static void Main(params string[] args) 
    {
        ICommandManager mapper = new CommandManager();

        //consoleapp1 sayhello -n Sebastian
        mapper.Register(new SayHelloCommand()); //CommandBaseWithOptions<T>

        //consoleapp1 sayhour 
        mapper.Register(new SayHourCommand()); //CommandBase


        //CommandName was calculated by reflection deleting 'Command' suffix.

        mapper.Execute(args);
    }
}
```

```csharp
using CommandMapper.CLI.Options;
using CommandMapper.Core.WithOptions;
using System;


namespace CommandMapper.CLI.Commands
{
    public class SayHelloCommand : CommandBaseWithOptions<NameOption>
    {
        protected override void CommandScript(NameOption options)
        {
            Console.WriteLine("Hello {0}!", options.Name);
        }
    }
}
```


```csharp
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.CLI.Options
{
    public class NameOption
    {
        [Option('n', "name", Required = true, HelpText = "El nombre del mono")]
        public string Name { get; set; } = null!;

        [Option('o', "onor", Required = false, HelpText = "Algo que no quiero pasar parametros")]
        public bool OptionX { get; set; }
    }
}
```


```csharp
using CommandMapper.Core.WithoutOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMapper.CLI.Commands
{
    public class SayHourCommand : CommandBase
    {
        protected override void CommandScript()
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}
```

## Options and Parameters

Options and parameters are configured following the single-line structure: "program <command [options]>".

## Customization

By extending the base interfaces and classes.

## Contributions

- Creating issues and proposing improvements. (I have already identified some)
- Long and readable code over short and unreadable. C# standards. Code improvements are accepted. Decoupling. Dependency inversion. Structural clarity. Fluent code.
- Apply dependency injection. Automatic command recognition using reflection. Customize the mapping between the Command class and the name in the dictionary.

## Support

For questions or support, you can contact me at jose-sebastian.garcia@outlook.com.

## License

MIT

## Gratitude

**Thank you for your support!**

Every contribution, big or small, keeps me motivated to continue developing and improving CommandMapper. Your support helps me stay focused and keep providing useful tools for the developer community!

----

<a href="https://www.buymeacoffee.com/josesebastiangarcia" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" style="height: 60px !important;width: 217px !important;" ></a>
