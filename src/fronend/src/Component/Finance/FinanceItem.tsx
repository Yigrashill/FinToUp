import React, { useState } from 'react'
import { FinanceProps } from '../../Types/Interfaces/Finance/FinanceProps';
import { formatDate, getFinanceTypeName } from '../../Services/UtilityService';
import FinanceTypeComp from './FinanceTypeComp';

const FinanceItem: React.FC<FinanceProps> = ({ finance }) => {
  
  return (
      <tr>

        <td className="p-2 border-b pl-10 border-gray-500">
              <div className=" flex items-center text-sm font-medium text-gray-300">
                { finance.title }
            </div>
        </td>

        <td className="p-2 border-b  border-gray-500">
            <p className="block antialiased font-sans text-sm leading-normal text-gray-300 font-normal">
                { finance.amount } zł
            </p>
        </td>

        <td className="p-2 border-b border-gray-500">
          <FinanceTypeComp financeType={finance.financeType} />
        </td>

        <td className="p-2 border-b border-gray-500">
            <p className="block antialiased font-sans text-sm leading-normal text-gray-300 font-normal">
               { formatDate(finance.createrd) }
            </p>
        </td>

      </tr>
  )
}

export default FinanceItem