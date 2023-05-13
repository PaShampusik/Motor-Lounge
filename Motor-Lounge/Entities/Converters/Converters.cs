using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Motor_Lounge.Entities.Cars;
using Motor_Lounge.Entities.Helpers;
using Newtonsoft.Json;

namespace Motor_Lounge.Entities.Converters
{
    public class CarConverter : ValueConverter<Car, string>
    {
        public CarConverter(ConverterMappingHints mappingHints = null)
            : base(
                car => JsonConvert.SerializeObject(car),
                json => JsonConvert.DeserializeObject<Car>(json),
                mappingHints)
        {
        }
    }

    public class AppearanceConverter : ValueConverter<Appearance, string>
    {
        public AppearanceConverter(ConverterMappingHints mappingHints = null)
            : base(
                appearance => JsonConvert.SerializeObject(appearance),
                json => JsonConvert.DeserializeObject<Appearance>(json),
                mappingHints)
        {
        }
    }

    public class CharacteristicsConverter : ValueConverter<Characteristics, string>
    {
        public CharacteristicsConverter(ConverterMappingHints mappingHints = null)
            : base(
                characteristics => JsonConvert.SerializeObject(characteristics),
                json => JsonConvert.DeserializeObject<Characteristics>(json),
                mappingHints)
        {
        }
    }

    public class EquipmentConverter : ValueConverter<Equipment, string>
    {
        public EquipmentConverter(ConverterMappingHints mappingHints = null)
            : base(
                equipment => JsonConvert.SerializeObject(equipment),
                json => JsonConvert.DeserializeObject<Equipment>(json),
                mappingHints)
        {
        }
    }

    public class SpecificationConverter : ValueConverter<Specification, string>
    {
        public SpecificationConverter(ConverterMappingHints mappingHints = null)
            : base(
                specification => JsonConvert.SerializeObject(specification),
                json => JsonConvert.DeserializeObject<Specification>(json),
                mappingHints)
        {
        }
    }

    public class InformationConverter : ValueConverter<Information,  string> 
    {
        public InformationConverter(ConverterMappingHints mappingHints = null)
           : base(
               information => JsonConvert.SerializeObject(information),
               json => JsonConvert.DeserializeObject<Information>(json),
               mappingHints)
        {
        }
    }

    public class PhotosConverter : ValueConverter<Photo, string>
    {
        public PhotosConverter(ConverterMappingHints mappingHints = null)
          : base(
              photo => JsonConvert.SerializeObject(photo),
              json => JsonConvert.DeserializeObject<Photo>(json),
              mappingHints)
        {
        }
    }

    public class PriceConverter : ValueConverter<Price, string>
    {
        public PriceConverter(ConverterMappingHints mappingHints = null)
          : base(
              price => JsonConvert.SerializeObject(price),
              json => JsonConvert.DeserializeObject<Price>(json),
              mappingHints)
        {
        }
    }
}