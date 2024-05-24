import React from 'react'
import { FinanceTypeProps } from '../../Types/Interfaces/Finance/FinanceProps';
import { getFinanceTypeName } from '../../Services/UtilityService';
import { FinanceType } from '../../Types/Enum/FinanceType';


 const FinanceTypeComp: React.FC<FinanceTypeProps> = ({ financeType }) => {

  return (
        <div className="w-max relative grid items-center font-sans font-bold uppercase whitespace-nowrap select-none py-1 px-2 text-xs rounded-md">
          {
            financeType === FinanceType.Assets ? (
              <span className=' bg-green-500/20 text-green-900'>
                { getFinanceTypeName(financeType) }
              </span>
            ) :(
              <span className=' bg-red-500/20 text-red-900'>
                { getFinanceTypeName(financeType) }
              </span>
            )
          }
        </div>
  )
}

export default FinanceTypeComp