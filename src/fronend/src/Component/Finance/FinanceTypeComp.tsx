import React from 'react'
import { FinanceTypeProps } from '../../Types/Interfaces/Finance/FinanceProps';
import { getFinanceTypeName } from '../../Services/UtilityService';
import { FinanceType } from '../../Types/Enum/FinanceType';


 const FinanceTypeComp: React.FC<FinanceTypeProps> = ({ financeType }) => {

  return (
        <div className="items-center font-sans font-bold uppercase py-4 px-10 min-w-10">
          {
            financeType === FinanceType.Assets ? (
              <span className=' bg-green-800 text-gray-200'>
                { getFinanceTypeName(financeType) }
              </span>
            ) :(
              <span className=' bg-red-800 text-gray-200'>
                { getFinanceTypeName(financeType) }
              </span>
            )
          }
        </div>
  )
}

export default FinanceTypeComp